// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Core
{
    public static partial class PFLocalUser
    {
        public static PFResult<PFLocalUserHandle> PFLocalUserCreateHandleWithPersistedLocalId(PFServiceConfigHandle serviceConfigHandle, string persistedLocalId, PFLocalUserLoginHandler loginHandler, object customContext)
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                sbyte* persistedLocalIdInterop;
                WrapperHelpers.StringToInterop(persistedLocalId, &persistedLocalIdInterop, disposableBuffer);
                IntPtr localUserHandleInterop;
                int hr = Interop.Methods.PFLocalUserCreateHandleWithPersistedLocalId(serviceConfigHandle.Handle, persistedLocalIdInterop, _PFLocalUserLoginHandlerManager.GetInteropCallback(), null, &localUserHandleInterop);

                if (HRESULT.Succeeded(hr))
                {
                    PFLocalUserHandle localUserHandle = new(localUserHandleInterop);
                    IntPtr callbackId = MapLocalUserToCallbackIdAndCustomContext(localUserHandle, customContext);
                    _PFLocalUserLoginHandlerManager.AddLocalUserHandler(callbackId, loginHandler);

                    return new(localUserHandle, hr);
                }

                return new(hr);
            }
        }

        public static PFResult<PFLocalUserHandle> PFLocalUserDuplicateHandle(PFLocalUserHandle handle)
        {
            unsafe
            {
                IntPtr duplicatedHandleInterop;
                int hr = Interop.Methods.PFLocalUserDuplicateHandle(handle.Handle, &duplicatedHandleInterop);
                PFLocalUserHandle duplicatedHandle = new(duplicatedHandleInterop);

                return HRESULT.Failed(hr) ? new(hr)
                                          : new(duplicatedHandle, hr);
            }
        }

        public static void PFLocalUserCloseHandle(PFLocalUserHandle localUserHandle)
        {
            Interop.Methods.PFLocalUserCloseHandle(localUserHandle.Handle);
        }

        public static int PFLocalUserHandleCompare(PFLocalUserHandle user1, PFLocalUserHandle user2)
        {
            return Interop.Methods.PFLocalUserHandleCompare(user1.Handle, user2.Handle);
        }

        public static PFResult<PFServiceConfigHandle> PFLocalUserGetServiceConfigHandle(PFLocalUserHandle localUserHandle)
        {
            unsafe
            {
                IntPtr serviceConfigHandleInterop;
                int hr = Interop.Methods.PFLocalUserGetServiceConfigHandle(localUserHandle.Handle, &serviceConfigHandleInterop);
                PFServiceConfigHandle serviceConfigHandle = new(serviceConfigHandleInterop);

                return HRESULT.Failed(hr) ? new(hr)
                                          : new(serviceConfigHandle, hr);
            }
        }

        public static PFResult<string> PFLocalUserGetLocalId(PFLocalUserHandle localUserHandle)
        {
            unsafe
            {
                ulong localIdSize;
                int hr = Interop.Methods.PFLocalUserGetLocalIdSize(localUserHandle.Handle, &localIdSize);

                if (HRESULT.Failed(hr))
                {
                    return new(hr);
                }

                sbyte* localIdInterop = stackalloc sbyte[(int)localIdSize];
                hr = Interop.Methods.PFLocalUserGetLocalId(localUserHandle.Handle, localIdSize, localIdInterop, null);
                
                return HRESULT.Failed(hr) ? new(hr)
                                          : new(WrapperHelpers.InteropToString(localIdInterop), hr);
            }
        }

        public static PFResult<object> PFLocalUserGetCustomContext(PFLocalUserHandle localUserHandle)
        {
            if (TryGetCustomContextForLocalUser(localUserHandle, out object customContext))
            {
                return new(customContext, HRESULT.S_OK);
            }
            
            return new(null, HRESULT.S_OK);
        }

        public static PFResult<PFEntityHandle> PFLocalUserTryGetEntityHandle(PFLocalUserHandle localUserHandle)
        {
            unsafe
            {
                IntPtr* entityHandleInterop = stackalloc IntPtr[1];
                int hr = Interop.Methods.PFLocalUserTryGetEntityHandle(localUserHandle.Handle, entityHandleInterop);
                PFEntityHandle entityHandle = new(*entityHandleInterop);

                return HRESULT.Failed(hr) ? new(hr)
                                          : new(entityHandle, hr);
            }
        }

        public static Task<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> PFLocalUserLoginAsync(PFLocalUserHandle localUserHandle, bool createAccount)
        {
            TaskCompletionSource<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFLocalUserLoginGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    IntPtr entityHandle;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFLocalUserLoginGetResult(asyncBlock, &entityHandle, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(entityHandle), new(*result)), hr));
                });

                int hr = Interop.Methods.PFLocalUserLoginAsync(localUserHandle.Handle, WrapperHelpers.BoolToInterop(createAccount), (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        private static readonly Dictionary<string, IntPtr> _LocalIdToCallbackId = new();
        private static readonly Dictionary<string, object> _LocalIdToCustomContext = new();

        private static IntPtr MapLocalUserToCallbackIdAndCustomContext(PFLocalUserHandle localUserHandle, object customContext)
        {
            var localIdResult = PFLocalUserGetLocalId(localUserHandle);
            if (localIdResult.Succeeded())
            {
                IntPtr uniqueId = _PFLocalUserLoginHandlerManager.GetUniqueInternalContext();
                _LocalIdToCallbackId.TryAdd(localIdResult.Result, uniqueId);
                _LocalIdToCustomContext.TryAdd(localIdResult.Result, customContext);

                return uniqueId;
            }

            return IntPtr.Zero;
        }

        private static bool TryGetCallbackIdForLocalUser(PFLocalUserHandle localUserHandle, out IntPtr callbackId)
        {
            var localIdResult = PFLocalUserGetLocalId(localUserHandle);
            if (localIdResult.Succeeded() &&
                _LocalIdToCallbackId.TryGetValue(localIdResult.Result, out callbackId))
            {
                return true;
            }

            callbackId = IntPtr.Zero;
            return false;
        }

        private static bool TryGetCustomContextForLocalUser(PFLocalUserHandle localUserHandle, out object customContext)
        {
            var localIdResult = PFLocalUserGetLocalId(localUserHandle);
            if (localIdResult.Succeeded() &&
                _LocalIdToCustomContext.TryGetValue(localIdResult.Result, out customContext))
            {
                return true;
            }

            customContext = null;
            return false;
        }

        private static readonly PFLocalUserLoginHandlerManager _PFLocalUserLoginHandlerManager = new();

        private class PFLocalUserLoginHandlerManager :
            InteropMultiCallbackManager<PFLocalUserLoginHandler>
        {
            private Interop.PFLocalUserLoginHandler _interopCallback;

            internal unsafe Interop.PFLocalUserLoginHandler GetInteropCallback()
            {
                if (_interopCallback == null)
                {
                    _interopCallback = new Interop.PFLocalUserLoginHandler(InteropPInvokeCallback);
                }
                return _interopCallback;
            }

            internal unsafe int InteropPInvokeCallback(IntPtr localUserHandle, IntPtr serviceConfigHandle, IntPtr existingEntityHandle, Interop.XAsyncBlock* block)
            {
                if (!TryGetCallbackIdForLocalUser(new(localUserHandle), out IntPtr callbackId) ||
                    !CallbackIdToHandler.ContainsKey(callbackId))
                {
                    return HRESULT.E_PF_INVALIDHANDLE;
                }

                var localUser = new PlayFab.PFLocalUser(new(localUserHandle));
                var serviceConfig = new PlayFab.PFServiceConfig(new(serviceConfigHandle));
                var existingPlayer = existingEntityHandle == IntPtr.Zero ? null
                                                                         : new PlayFab.PFPlayerEntity(new(existingEntityHandle), null);
                var handlerContext = new PFLocalUserLoginHandlerContext(new Interop.XAsyncBlockPtr(new IntPtr(block)));

                return IssueEventCallback(callbackId, localUser, serviceConfig, existingPlayer, handlerContext);
            }

            internal void AddLocalUserHandler(IntPtr callbackId, PFLocalUserLoginHandler callback)
            {
                AddCallbackForId(callbackId, callback, null, IntPtr.Zero);
            }

            private int IssueEventCallback(IntPtr id, PlayFab.PFLocalUser localUser, PlayFab.PFServiceConfig serviceConfig, PlayFab.PFPlayerEntity existingPlayer, PFLocalUserLoginHandlerContext handlerContext)
            {
                return CallbackIdToHandler[id].Callback?.Invoke(localUser, serviceConfig, existingPlayer, handlerContext) ?? HRESULT.E_FAIL;
            }
        }
    }
}
