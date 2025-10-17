// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Core
{
    public static class PFEntity
    {
        public static PFResult<PFEntityHandle> PFEntityDuplicateHandle(PFEntityHandle handle)
        {
            unsafe
            {
                IntPtr duplicatedHandleInterop;
                int hr = Interop.Methods.PFEntityDuplicateHandle(handle.Handle, &duplicatedHandleInterop);
                PFEntityHandle duplicatedHandle = new(duplicatedHandleInterop);

                return HRESULT.Failed(hr) ? new(hr)
                                          : new(duplicatedHandle, hr);
            }
        }

        public static void PFEntityCloseHandle(PFEntityHandle entityHandle)
        {
            Interop.Methods.PFEntityCloseHandle(entityHandle.Handle);
        }

        public static Task<PFResult<PFEntityToken>> PFEntityGetEntityTokenAsync(PFEntityHandle entityHandle)
        {
            TaskCompletionSource<PFResult<PFEntityToken>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFEntityGetEntityTokenResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFEntityToken* result;

                    hr = Interop.Methods.PFEntityGetEntityTokenResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                int hr = Interop.Methods.PFEntityGetEntityTokenAsync(entityHandle.Handle, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        public static PFResult<string> PFEntityGetSecretKey(PFEntityHandle entityHandle)
        {
            unsafe
            {
                ulong secretKeySize;
                int hr = Interop.Methods.PFEntityGetSecretKeySize(entityHandle.Handle, &secretKeySize);

                if (HRESULT.Failed(hr))
                {
                    return new(hr);
                }

                sbyte* secretKeyInterop = stackalloc sbyte[(int)secretKeySize];
                hr = Interop.Methods.PFEntityGetSecretKey(entityHandle.Handle, secretKeySize, secretKeyInterop, null);
                
                return HRESULT.Failed(hr) ? new(hr)
                                          : new(WrapperHelpers.InteropToString(secretKeyInterop), hr);
            }
        }

        public static PFResult<PFEntityKey> PFEntityGetEntityKey(PFEntityHandle entityHandle)
        {
            unsafe
            {
                ulong entityKeySize;
                int hr = Interop.Methods.PFEntityGetEntityKeySize(entityHandle.Handle, &entityKeySize);

                if (HRESULT.Failed(hr))
                {
                    return new(hr);
                }

                using DisposableBuffer disposableBuffer = new();
                void* buffer = disposableBuffer.AddBuffer((int)entityKeySize).ToPointer();
                Interop.PFEntityKey* entityKeyInterop = stackalloc Interop.PFEntityKey[1];

                hr = Interop.Methods.PFEntityGetEntityKey(entityHandle.Handle, entityKeySize, buffer, &entityKeyInterop, null);
                
                return HRESULT.Failed(hr) ? new(hr)
                                          : new(new(*entityKeyInterop), hr);
            }
        }

        public static PFResult<bool> PFEntityIsTitlePlayer(PFEntityHandle entityHandle)
        {
            unsafe
            {
                byte isTitlePlayer;
                int hr = Interop.Methods.PFEntityIsTitlePlayer(entityHandle.Handle, &isTitlePlayer);

                return HRESULT.Failed(hr) ? new(hr)
                                          : new(WrapperHelpers.InteropToBool(isTitlePlayer), hr);
            }
        }

        public static PFResult<string> PFEntityGetAPIEndpoint(PFEntityHandle entityHandle)
        {
            unsafe
            {
                ulong apiEndpointSize;
                int hr = Interop.Methods.PFEntityGetAPIEndpointSize(entityHandle.Handle, &apiEndpointSize);

                if (HRESULT.Failed(hr))
                {
                    return new(hr);
                }

                sbyte* apiEndpointInterop = stackalloc sbyte[(int)apiEndpointSize];
                hr = Interop.Methods.PFEntityGetAPIEndpoint(entityHandle.Handle, apiEndpointSize, apiEndpointInterop, null);

                return HRESULT.Failed(hr) ? new(hr)
                                          : new(WrapperHelpers.InteropToString(apiEndpointInterop), hr);
            }
        }

        public static PFResult<string> PFEntityGetTitleId(PFEntityHandle entityHandle)
        {
            unsafe
            {
                ulong titleIdSize;
                int hr = Interop.Methods.PFEntityGetTitleIdSize(entityHandle.Handle, &titleIdSize);

                if (HRESULT.Failed(hr))
                {
                    return new(hr);
                }

                sbyte* titleIdInterop = stackalloc sbyte[(int)titleIdSize];
                hr = Interop.Methods.PFEntityGetTitleId(entityHandle.Handle, titleIdSize, titleIdInterop, null);

                return HRESULT.Failed(hr) ? new(hr)
                                          : new(WrapperHelpers.InteropToString(titleIdInterop), hr);
            }
        }

        public static PFResult<PFCallbackToken> PFEntityRegisterTokenExpiredEventHandler(PFEntityTokenExpiredEventHandler handler, object context)
        {
            return _PFEntityTokenExpiredEventHandlerManager.AddCallback(handler, context);
        }

        public static void PFEntityUnregisterTokenExpiredEventHandler(PFCallbackToken token)
        {
            _PFEntityTokenExpiredEventHandlerManager.RemoveCallback(token);
        }

        public static PFResult<PFCallbackToken> PFEntityRegisterTokenRefreshedEventHandler(PFEntityTokenRefreshedEventHandler handler, object context)
        {
            return _PFEntityTokenRefreshedEventHandlerManager.AddCallback(handler, context);
        }

        public static void PFEntityUnregisterTokenRefreshedEventHandler(PFCallbackToken token)
        {
            _PFEntityTokenRefreshedEventHandlerManager.RemoveCallback(token);
        }

        private static readonly PFEntityTokenExpiredEventHandlerManager _PFEntityTokenExpiredEventHandlerManager = new();
        private static readonly PFEntityTokenRefreshedEventHandlerManager _PFEntityTokenRefreshedEventHandlerManager = new();

        private class PFEntityTokenExpiredEventHandlerManager :
            InteropMultiCallbackManager<PFEntityTokenExpiredEventHandler>
        {
            private readonly Dictionary<IntPtr, ulong> IdToToken = new();
            private Interop.PFEntityTokenExpiredEventHandler _interopCallback;

            internal unsafe void InteropPInvokeCallback(void* context, Interop.PFEntityKey* entityKey)
            {
                IntPtr id = new(context);
                if (!CallbackIdToHandler.ContainsKey(id)) return;

                var entityKeyWrapper = new PFEntityKey(*entityKey);

                IssueEventCallback(id, entityKeyWrapper);
            }

            internal PFResult<PFCallbackToken> AddCallback(PFEntityTokenExpiredEventHandler callback, object context)
            {
                IntPtr idAndContext = GetUniqueInternalContext();
                ulong tokenInterop;
                int hr;

                unsafe
                {
                    if (_interopCallback == null)
                    {
                        _interopCallback = new Interop.PFEntityTokenExpiredEventHandler(InteropPInvokeCallback);
                    }
                    hr = Interop.Methods.PFEntityRegisterTokenExpiredEventHandler(AsyncHelpers.DefaultQueue.handle.intPtr, (void*)idAndContext, _interopCallback, &tokenInterop);
                }

                if (HRESULT.Succeeded(hr))
                {
                    IdToToken[idAndContext] = tokenInterop;
                    var token = AddCallbackForId(idAndContext, callback, context, idAndContext);
                    return new(token, hr);
                }

                return new(hr);
            }

            internal override void RemoveCallback(PFCallbackToken token)
            {
                Interop.Methods.PFEntityUnregisterTokenExpiredEventHandler(IdToToken[token.Id]);
                base.RemoveCallback(token);
            }

            private unsafe void IssueEventCallback(IntPtr id, PFEntityKey entityKey)
            {
                CallbackIdToHandler[id].Callback.Invoke(CallbackIdToHandler[id].Context, entityKey);
            }
        }

        private class PFEntityTokenRefreshedEventHandlerManager :
            InteropMultiCallbackManager<PFEntityTokenRefreshedEventHandler>
        {
            private readonly Dictionary<IntPtr, ulong> IdToToken = new();
            private Interop.PFEntityTokenRefreshedEventHandler _interopCallback;

            internal unsafe void InteropPInvokeCallback(void* context, Interop.PFEntityKey* entityKey, Interop.PFEntityToken* newToken)
            {
                IntPtr id = new(context);
                if (!CallbackIdToHandler.ContainsKey(id)) return;

                var entityKeyWrapper = new PFEntityKey(*entityKey);

                var newTokenWrapper = new PFEntityToken(*newToken);

                IssueEventCallback(id, entityKeyWrapper, newTokenWrapper);
            }

            internal PFResult<PFCallbackToken> AddCallback(PFEntityTokenRefreshedEventHandler callback, object context)
            {
                IntPtr idAndContext = GetUniqueInternalContext();
                ulong tokenInterop;
                int hr;

                unsafe
                {
                    if (_interopCallback == null)
                    {
                        _interopCallback = new Interop.PFEntityTokenRefreshedEventHandler(InteropPInvokeCallback);
                    }
                    hr = Interop.Methods.PFEntityRegisterTokenRefreshedEventHandler(AsyncHelpers.DefaultQueue.handle.intPtr, (void*)idAndContext, _interopCallback, &tokenInterop);
                }

                if (HRESULT.Succeeded(hr))
                {
                    IdToToken[idAndContext] = tokenInterop;
                    var token = AddCallbackForId(idAndContext, callback, context, idAndContext);
                    return new(token, hr);
                }

                return new(hr);
            }

            internal override void RemoveCallback(PFCallbackToken token)
            {
                Interop.Methods.PFEntityUnregisterTokenRefreshedEventHandler(IdToToken[token.Id]);
                base.RemoveCallback(token);
            }

            private unsafe void IssueEventCallback(IntPtr id, PFEntityKey entityKey, PFEntityToken newToken)
            {
                CallbackIdToHandler[id].Callback.Invoke(CallbackIdToHandler[id].Context, entityKey, newToken);
            }
        }
    }
}
