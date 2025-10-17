// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFCloudScript
    {

        /// <summary>
        /// Executes a CloudScript function, with the 'currentPlayerId' set to the PlayFab ID of the authenticated
        /// player. The PlayFab ID is the entity ID of the player's master_player_account entity.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCloudScriptExecuteCloudScriptResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCloudScriptClientExecuteCloudScriptGetResultSize"/>
        /// and <see cref="PFCloudScriptClientExecuteCloudScriptGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCloudScriptExecuteCloudScriptResult>> PFCloudScriptClientExecuteCloudScriptAsync(
            PFEntityHandle entityHandle,
            PFCloudScriptExecuteCloudScriptRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCloudScriptExecuteCloudScriptResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCloudScriptClientExecuteCloudScriptGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCloudScriptExecuteCloudScriptResult* result = null;

                    hr = Interop.Methods.PFCloudScriptClientExecuteCloudScriptGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCloudScriptExecuteCloudScriptRequest* requestInterop = stackalloc Interop.PFCloudScriptExecuteCloudScriptRequest[1];
                PFCloudScriptExecuteCloudScriptRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCloudScriptClientExecuteCloudScriptAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Executes a CloudScript function, with the 'currentPlayerId' set to the PlayFab ID of the authenticated
        /// player. The PlayFab ID is the entity ID of the player's master_player_account entity.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCloudScriptExecuteCloudScriptResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFCloudScriptServerExecuteCloudScriptGetResultSize"/>
        /// and <see cref="PFCloudScriptServerExecuteCloudScriptGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCloudScriptExecuteCloudScriptResult>> PFCloudScriptServerExecuteCloudScriptAsync(
            PFEntityHandle titleEntityHandle,
            PFCloudScriptExecuteCloudScriptServerRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCloudScriptExecuteCloudScriptResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCloudScriptServerExecuteCloudScriptGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCloudScriptExecuteCloudScriptResult* result = null;

                    hr = Interop.Methods.PFCloudScriptServerExecuteCloudScriptGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCloudScriptExecuteCloudScriptServerRequest* requestInterop = stackalloc Interop.PFCloudScriptExecuteCloudScriptServerRequest[1];
                PFCloudScriptExecuteCloudScriptServerRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCloudScriptServerExecuteCloudScriptAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Cloud Script is one of PlayFab's most versatile features. It allows client code to request execution
        /// of any kind of custom server-side functionality you can implement, and it can be used in conjunction
        /// with virtually anything.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCloudScriptExecuteCloudScriptResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Executes CloudScript with the entity profile that is defined in the request.
        ///
        /// When the asynchronous task is complete, call <see cref="PFCloudScriptExecuteEntityCloudScriptGetResultSize"/>
        /// and <see cref="PFCloudScriptExecuteEntityCloudScriptGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCloudScriptExecuteCloudScriptResult>> PFCloudScriptExecuteEntityCloudScriptAsync(
            PFEntityHandle entityHandle,
            PFCloudScriptExecuteEntityCloudScriptRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCloudScriptExecuteCloudScriptResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCloudScriptExecuteEntityCloudScriptGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCloudScriptExecuteCloudScriptResult* result = null;

                    hr = Interop.Methods.PFCloudScriptExecuteEntityCloudScriptGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCloudScriptExecuteEntityCloudScriptRequest* requestInterop = stackalloc Interop.PFCloudScriptExecuteEntityCloudScriptRequest[1];
                PFCloudScriptExecuteEntityCloudScriptRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCloudScriptExecuteEntityCloudScriptAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Cloud Script is one of PlayFab's most versatile features. It allows client code to request execution
        /// of any kind of custom server-side functionality you can implement, and it can be used in conjunction
        /// with virtually anything.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCloudScriptExecuteFunctionResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Executes an Azure Function with the profile of the entity that is defined in the request. See also
        /// CloudScriptRegisterHttpFunctionAsync, CloudScriptRegisterQueuedFunctionAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFCloudScriptExecuteFunctionGetResultSize"/>
        /// and <see cref="PFCloudScriptExecuteFunctionGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCloudScriptExecuteFunctionResult>> PFCloudScriptExecuteFunctionAsync(
            PFEntityHandle entityHandle,
            PFCloudScriptExecuteFunctionRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCloudScriptExecuteFunctionResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCloudScriptExecuteFunctionGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCloudScriptExecuteFunctionResult* result = null;

                    hr = Interop.Methods.PFCloudScriptExecuteFunctionGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCloudScriptExecuteFunctionRequest* requestInterop = stackalloc Interop.PFCloudScriptExecuteFunctionRequest[1];
                PFCloudScriptExecuteFunctionRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCloudScriptExecuteFunctionAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
