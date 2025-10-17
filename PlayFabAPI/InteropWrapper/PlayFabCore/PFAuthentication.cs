// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Core
{
    public static partial class PFAuthentication
    {
#if MICROSOFT_GDK_SUPPORT
        public static Task<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> PFAuthenticationLoginWithXUserAsync(
            PFServiceConfigHandle serviceConfigHandle,
            PFAuthenticationLoginWithXUserRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFEntityHandle entity, PFAuthenticationLoginResult loginResult)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFAuthenticationLoginWithXUserGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    IntPtr entityHandle;
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFAuthenticationLoginResult* result = null;

                    hr = Interop.Methods.PFAuthenticationLoginWithXUserGetResult(asyncBlock, &entityHandle, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new((new(entityHandle), new(*result)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithXUserRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithXUserRequest[1];
                PFAuthenticationLoginWithXUserRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationLoginWithXUserAsync(serviceConfigHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Reauthenticates an existing PFEntityHandle using an XUserHandle. Used to address situations where the EntityToken expired
        /// and the PlayFab SDK is unable to refresh it.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to re-login.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>Result code for this API operation.</returns>
        /// <remarks>
        /// If successful, the cached EntityToken for the PFEntityHandle will be updated in place.
        /// </remarks>
        public static Task<PFResult> PFAuthenticationReLoginWithXUserAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationLoginWithXUserRequest request
        )
        {
            TaskCompletionSource<PFResult> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    hr = Interop.Methods.XAsyncGetStatus(asyncBlock, WrapperHelpers.BoolToInterop(false));
                    completionSource.SetResult(new(hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationLoginWithXUserRequest* requestInterop = stackalloc Interop.PFAuthenticationLoginWithXUserRequest[1];
                PFAuthenticationLoginWithXUserRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationReLoginWithXUserAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                }
            }
            
            return completionSource.Task;
        }  
#endif

        /// <summary>
        /// Create a game_server entity token and return a new or existing game_server entity.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a (PFEntityHandle entity, bool newlyCreated).</returns>
        /// <remarks>
        /// This API is available on Win32, Linux, and macOS.
        /// Create or return a game_server entity token. Caller must be a title entity.
        ///
        /// When the asynchronous task is complete, call <see cref="PFAuthenticationAuthenticateGameServerWithCustomIdGetResultSize"/>
        /// and <see cref="PFAuthenticationAuthenticateGameServerWithCustomIdGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<(PFEntityHandle entity, bool newlyCreated)>> PFAuthenticationAuthenticateGameServerWithCustomIdAsync(
            PFEntityHandle entityHandle,
            PFAuthenticationAuthenticateCustomIdRequest request
        )
        {
            TaskCompletionSource<PFResult<(PFEntityHandle entity, bool newlyCreated)>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    IntPtr entityHandle;
                    byte newlyCreated;

                    hr = Interop.Methods.PFAuthenticationAuthenticateGameServerWithCustomIdGetResult(asyncBlock, &entityHandle, &newlyCreated);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    PFEntityHandle entity = new(entityHandle);
                    completionSource.SetResult(new((entity, WrapperHelpers.InteropToBool(newlyCreated)), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFAuthenticationAuthenticateCustomIdRequest* requestInterop = stackalloc Interop.PFAuthenticationAuthenticateCustomIdRequest[1];
                PFAuthenticationAuthenticateCustomIdRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFAuthenticationAuthenticateGameServerWithCustomIdAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }
            
            return completionSource.Task;
        }
    }
}
