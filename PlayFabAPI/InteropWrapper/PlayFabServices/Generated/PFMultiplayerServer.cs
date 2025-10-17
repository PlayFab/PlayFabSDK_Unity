// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFMultiplayerServer
    {

        /// <summary>
        /// Lists details of all build aliases for a title. Accepts tokens for title and if game client access
        /// is enabled, allows game client to request list of builds with player entity token.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFMultiplayerServerListBuildAliasesResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Returns a list of summarized details of all multiplayer server builds for a title. See also MultiplayerServerCreateBuildWithManagedContainerAsync,
        /// MultiplayerServerDeleteBuildAsync, MultiplayerServerGetBuildAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFMultiplayerServerListBuildAliasesGetResultSize"/>
        /// and <see cref="PFMultiplayerServerListBuildAliasesGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFMultiplayerServerListBuildAliasesResponse>> PFMultiplayerServerListBuildAliasesAsync(
            PFEntityHandle entityHandle,
            PFMultiplayerServerListBuildAliasesRequest request
        )
        {
            TaskCompletionSource<PFResult<PFMultiplayerServerListBuildAliasesResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFMultiplayerServerListBuildAliasesGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFMultiplayerServerListBuildAliasesResponse* result = null;

                    hr = Interop.Methods.PFMultiplayerServerListBuildAliasesGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFMultiplayerServerListBuildAliasesRequest* requestInterop = stackalloc Interop.PFMultiplayerServerListBuildAliasesRequest[1];
                PFMultiplayerServerListBuildAliasesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFMultiplayerServerListBuildAliasesAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Lists summarized details of all multiplayer server builds for a title. Accepts tokens for title and
        /// if game client access is enabled, allows game client to request list of builds with player entity
        /// token.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFMultiplayerServerListBuildSummariesResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Returns a list of summarized details of all multiplayer server builds for a title. See also MultiplayerServerCreateBuildWithManagedContainerAsync,
        /// MultiplayerServerDeleteBuildAsync, MultiplayerServerGetBuildAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFMultiplayerServerListBuildSummariesV2GetResultSize"/>
        /// and <see cref="PFMultiplayerServerListBuildSummariesV2GetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFMultiplayerServerListBuildSummariesResponse>> PFMultiplayerServerListBuildSummariesV2Async(
            PFEntityHandle entityHandle,
            PFMultiplayerServerListBuildSummariesRequest request
        )
        {
            TaskCompletionSource<PFResult<PFMultiplayerServerListBuildSummariesResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFMultiplayerServerListBuildSummariesV2GetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFMultiplayerServerListBuildSummariesResponse* result = null;

                    hr = Interop.Methods.PFMultiplayerServerListBuildSummariesV2GetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFMultiplayerServerListBuildSummariesRequest* requestInterop = stackalloc Interop.PFMultiplayerServerListBuildSummariesRequest[1];
                PFMultiplayerServerListBuildSummariesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFMultiplayerServerListBuildSummariesV2Async(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Lists quality of service servers for the title. By default, servers are only returned for regions
        /// where a Multiplayer Servers build has been deployed.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFMultiplayerServerListQosServersForTitleResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Returns a list of quality of service servers for a title.
        ///
        /// When the asynchronous task is complete, call <see cref="PFMultiplayerServerListQosServersForTitleGetResultSize"/>
        /// and <see cref="PFMultiplayerServerListQosServersForTitleGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFMultiplayerServerListQosServersForTitleResponse>> PFMultiplayerServerListQosServersForTitleAsync(
            PFEntityHandle entityHandle,
            PFMultiplayerServerListQosServersForTitleRequest request
        )
        {
            TaskCompletionSource<PFResult<PFMultiplayerServerListQosServersForTitleResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFMultiplayerServerListQosServersForTitleGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFMultiplayerServerListQosServersForTitleResponse* result = null;

                    hr = Interop.Methods.PFMultiplayerServerListQosServersForTitleGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFMultiplayerServerListQosServersForTitleRequest* requestInterop = stackalloc Interop.PFMultiplayerServerListQosServersForTitleRequest[1];
                PFMultiplayerServerListQosServersForTitleRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFMultiplayerServerListQosServersForTitleAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Request a multiplayer server session. Accepts tokens for title and if game client access is enabled,
        /// allows game client to request a server with player entity token.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFMultiplayerServerRequestMultiplayerServerResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Requests a multiplayer server session from a particular build in any of the given preferred regions.
        /// See also MultiplayerServerGetMultiplayerServerDetailsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFMultiplayerServerRequestMultiplayerServerGetResultSize"/>
        /// and <see cref="PFMultiplayerServerRequestMultiplayerServerGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFMultiplayerServerRequestMultiplayerServerResponse>> PFMultiplayerServerRequestMultiplayerServerAsync(
            PFEntityHandle entityHandle,
            PFMultiplayerServerRequestMultiplayerServerRequest request
        )
        {
            TaskCompletionSource<PFResult<PFMultiplayerServerRequestMultiplayerServerResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFMultiplayerServerRequestMultiplayerServerGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFMultiplayerServerRequestMultiplayerServerResponse* result = null;

                    hr = Interop.Methods.PFMultiplayerServerRequestMultiplayerServerGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFMultiplayerServerRequestMultiplayerServerRequest* requestInterop = stackalloc Interop.PFMultiplayerServerRequestMultiplayerServerRequest[1];
                PFMultiplayerServerRequestMultiplayerServerRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFMultiplayerServerRequestMultiplayerServerAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
