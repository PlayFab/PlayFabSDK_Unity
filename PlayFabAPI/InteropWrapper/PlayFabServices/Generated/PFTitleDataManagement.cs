// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFTitleDataManagement
    {

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFTitleDataManagementGetPublisherDataResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// This API is designed to return publisher-specific values which can be read, but not written to, by
        /// the client. This data is shared across all titles assigned to a particular publisher, and can be used
        /// for cross-game coordination. Only titles assigned to a publisher can use this API. For more information
        /// email helloplayfab@microsoft.com. Note that there may up to a minute delay in between updating title
        /// data and this API call returning the newest value.
        ///
        /// When the asynchronous task is complete, call <see cref="PFTitleDataManagementClientGetPublisherDataGetResultSize"/>
        /// and <see cref="PFTitleDataManagementClientGetPublisherDataGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFTitleDataManagementGetPublisherDataResult>> PFTitleDataManagementClientGetPublisherDataAsync(
            PFEntityHandle entityHandle,
            PFTitleDataManagementGetPublisherDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFTitleDataManagementGetPublisherDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFTitleDataManagementClientGetPublisherDataGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFTitleDataManagementGetPublisherDataResult* result = null;

                    hr = Interop.Methods.PFTitleDataManagementClientGetPublisherDataGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFTitleDataManagementGetPublisherDataRequest* requestInterop = stackalloc Interop.PFTitleDataManagementGetPublisherDataRequest[1];
                PFTitleDataManagementGetPublisherDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFTitleDataManagementClientGetPublisherDataAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the current server time
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFTitleDataManagementGetTimeResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// This query retrieves the current time from one of the servers in PlayFab. Please note that due to
        /// clock drift between servers, there is a potential variance of up to 5 seconds.
        ///
        /// When the asynchronous task is complete, call <see cref="PFTitleDataManagementClientGetTimeGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<PFTitleDataManagementGetTimeResult>> PFTitleDataManagementClientGetTimeAsync(
            PFEntityHandle entityHandle
        )
        {
            TaskCompletionSource<PFResult<PFTitleDataManagementGetTimeResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    Interop.PFTitleDataManagementGetTimeResult result = default;

                    hr = Interop.Methods.PFTitleDataManagementClientGetTimeGetResult(asyncBlock, &result);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(result), hr));
                });

                int hr = Interop.Methods.PFTitleDataManagementClientGetTimeAsync(entityHandle.Handle, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFTitleDataManagementGetTitleDataResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// This API is designed to return title specific values which can be read, but not written to, by the
        /// client. For example, a developer could choose to store values which modify the user experience, such
        /// as enemy spawn rates, weapon strengths, movement speeds, etc. This allows a developer to update the
        /// title without the need to create, test, and ship a new build. If the player belongs to an experiment
        /// variant that uses title data overrides, the overrides are applied automatically and returned with
        /// the title data. Note that there may up to a minute delay in between updating title data and this API
        /// call returning the newest value.
        ///
        /// When the asynchronous task is complete, call <see cref="PFTitleDataManagementClientGetTitleDataGetResultSize"/>
        /// and <see cref="PFTitleDataManagementClientGetTitleDataGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFTitleDataManagementGetTitleDataResult>> PFTitleDataManagementClientGetTitleDataAsync(
            PFEntityHandle entityHandle,
            PFTitleDataManagementGetTitleDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFTitleDataManagementGetTitleDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFTitleDataManagementClientGetTitleDataGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFTitleDataManagementGetTitleDataResult* result = null;

                    hr = Interop.Methods.PFTitleDataManagementClientGetTitleDataGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFTitleDataManagementGetTitleDataRequest* requestInterop = stackalloc Interop.PFTitleDataManagementGetTitleDataRequest[1];
                PFTitleDataManagementGetTitleDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFTitleDataManagementClientGetTitleDataAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the title news feed, as configured in the developer portal
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFTitleDataManagementGetTitleNewsResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFTitleDataManagementClientGetTitleNewsGetResultSize"/>
        /// and <see cref="PFTitleDataManagementClientGetTitleNewsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFTitleDataManagementGetTitleNewsResult>> PFTitleDataManagementClientGetTitleNewsAsync(
            PFEntityHandle entityHandle,
            PFTitleDataManagementGetTitleNewsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFTitleDataManagementGetTitleNewsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFTitleDataManagementClientGetTitleNewsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFTitleDataManagementGetTitleNewsResult* result = null;

                    hr = Interop.Methods.PFTitleDataManagementClientGetTitleNewsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFTitleDataManagementGetTitleNewsRequest* requestInterop = stackalloc Interop.PFTitleDataManagementGetTitleNewsRequest[1];
                PFTitleDataManagementGetTitleNewsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFTitleDataManagementClientGetTitleNewsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the key-value store of custom publisher settings
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFTitleDataManagementGetPublisherDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This API is designed to return publisher-specific values which can be read, but not written to, by
        /// the client. This data is shared across all titles assigned to a particular publisher, and can be used
        /// for cross-game coordination. Only titles assigned to a publisher can use this API. For more information
        /// email helloplayfab@microsoft.com. Note that there may up to a minute delay in between updating title
        /// data and this API call returning the newest value. See also ServerSetPublisherDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFTitleDataManagementServerGetPublisherDataGetResultSize"/>
        /// and <see cref="PFTitleDataManagementServerGetPublisherDataGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFTitleDataManagementGetPublisherDataResult>> PFTitleDataManagementServerGetPublisherDataAsync(
            PFEntityHandle titleEntityHandle,
            PFTitleDataManagementGetPublisherDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFTitleDataManagementGetPublisherDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFTitleDataManagementServerGetPublisherDataGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFTitleDataManagementGetPublisherDataResult* result = null;

                    hr = Interop.Methods.PFTitleDataManagementServerGetPublisherDataGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFTitleDataManagementGetPublisherDataRequest* requestInterop = stackalloc Interop.PFTitleDataManagementGetPublisherDataRequest[1];
                PFTitleDataManagementGetPublisherDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFTitleDataManagementServerGetPublisherDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the current server time
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFTitleDataManagementGetTimeResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This query retrieves the current time from one of the servers in PlayFab. Please note that due to
        /// clock drift between servers, there is a potential variance of up to 5 seconds.
        ///
        /// When the asynchronous task is complete, call <see cref="PFTitleDataManagementServerGetTimeGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<PFTitleDataManagementGetTimeResult>> PFTitleDataManagementServerGetTimeAsync(
            PFEntityHandle titleEntityHandle
        )
        {
            TaskCompletionSource<PFResult<PFTitleDataManagementGetTimeResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    Interop.PFTitleDataManagementGetTimeResult result = default;

                    hr = Interop.Methods.PFTitleDataManagementServerGetTimeGetResult(asyncBlock, &result);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(result), hr));
                });

                int hr = Interop.Methods.PFTitleDataManagementServerGetTimeAsync(titleEntityHandle.Handle, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the key-value store of custom title settings
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFTitleDataManagementGetTitleDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This API is designed to return title specific values which can be read, but not written to, by the
        /// client. For example, a developer could choose to store values which modify the user experience, such
        /// as enemy spawn rates, weapon strengths, movement speeds, etc. This allows a developer to update the
        /// title without the need to create, test, and ship a new build. If an override label is specified in
        /// the request, the overrides are applied automatically and returned with the title data. Note that there
        /// may up to a minute delay in between updating title data and this API call returning the newest value.
        /// See also ServerSetTitleDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFTitleDataManagementServerGetTitleDataGetResultSize"/>
        /// and <see cref="PFTitleDataManagementServerGetTitleDataGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFTitleDataManagementGetTitleDataResult>> PFTitleDataManagementServerGetTitleDataAsync(
            PFEntityHandle titleEntityHandle,
            PFTitleDataManagementGetTitleDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFTitleDataManagementGetTitleDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFTitleDataManagementServerGetTitleDataGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFTitleDataManagementGetTitleDataResult* result = null;

                    hr = Interop.Methods.PFTitleDataManagementServerGetTitleDataGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFTitleDataManagementGetTitleDataRequest* requestInterop = stackalloc Interop.PFTitleDataManagementGetTitleDataRequest[1];
                PFTitleDataManagementGetTitleDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFTitleDataManagementServerGetTitleDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the key-value store of custom internal title settings
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFTitleDataManagementGetTitleDataResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This API is designed to return title specific values which are accessible only to the server. This
        /// can be used to tweak settings on game servers and Cloud Scripts without needed to update and re-deploy
        /// them. Note that there may up to a minute delay in between updating title data and this API call returning
        /// the newest value. See also ServerSetTitleInternalDataAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFTitleDataManagementServerGetTitleInternalDataGetResultSize"/>
        /// and <see cref="PFTitleDataManagementServerGetTitleInternalDataGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFTitleDataManagementGetTitleDataResult>> PFTitleDataManagementServerGetTitleInternalDataAsync(
            PFEntityHandle titleEntityHandle,
            PFTitleDataManagementGetTitleDataRequest request
        )
        {
            TaskCompletionSource<PFResult<PFTitleDataManagementGetTitleDataResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFTitleDataManagementServerGetTitleInternalDataGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFTitleDataManagementGetTitleDataResult* result = null;

                    hr = Interop.Methods.PFTitleDataManagementServerGetTitleInternalDataGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFTitleDataManagementGetTitleDataRequest* requestInterop = stackalloc Interop.PFTitleDataManagementGetTitleDataRequest[1];
                PFTitleDataManagementGetTitleDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFTitleDataManagementServerGetTitleInternalDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves the title news feed, as configured in the developer portal
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFTitleDataManagementGetTitleNewsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFTitleDataManagementServerGetTitleNewsGetResultSize"/>
        /// and <see cref="PFTitleDataManagementServerGetTitleNewsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFTitleDataManagementGetTitleNewsResult>> PFTitleDataManagementServerGetTitleNewsAsync(
            PFEntityHandle titleEntityHandle,
            PFTitleDataManagementGetTitleNewsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFTitleDataManagementGetTitleNewsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFTitleDataManagementServerGetTitleNewsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFTitleDataManagementGetTitleNewsResult* result = null;

                    hr = Interop.Methods.PFTitleDataManagementServerGetTitleNewsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFTitleDataManagementGetTitleNewsRequest* requestInterop = stackalloc Interop.PFTitleDataManagementGetTitleNewsRequest[1];
                PFTitleDataManagementGetTitleNewsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFTitleDataManagementServerGetTitleNewsAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates the key-value store of custom publisher settings
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This API is designed to store publisher-specific values which can be read, but not written to, by
        /// the client. This data is shared across all titles assigned to a particular publisher, and can be used
        /// for cross-game coordination. Only titles assigned to a publisher can use this API. This operation
        /// is additive. If a Key does not exist in the current dataset, it will be added with the specified Value.
        /// If it already exists, the Value for that key will be overwritten with the new Value. For more information
        /// email helloplayfab@microsoft.com See also ServerGetPublisherDataAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_PUBLISHER_NOT_SET or any of the global PlayFab Service errors. See doc
        /// page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFTitleDataManagementServerSetPublisherDataAsync(
            PFEntityHandle titleEntityHandle,
            PFTitleDataManagementSetPublisherDataRequest request
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
                Interop.PFTitleDataManagementSetPublisherDataRequest* requestInterop = stackalloc Interop.PFTitleDataManagementSetPublisherDataRequest[1];
                PFTitleDataManagementSetPublisherDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFTitleDataManagementServerSetPublisherDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This API is designed to store title specific values which can be read, but not written to, by the
        /// client. For example, a developer could choose to store values which modify the user experience, such
        /// as enemy spawn rates, weapon strengths, movement speeds, etc. This allows a developer to update the
        /// title without the need to create, test, and ship a new build. This operation is additive. If a Key
        /// does not exist in the current dataset, it will be added with the specified Value. If it already exists,
        /// the Value for that key will be overwritten with the new Value. See also ServerGetTitleDataAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_DATA_LENGTH_EXCEEDED, E_PF_TOO_MANY_KEYS or any of the global PlayFab
        /// Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFTitleDataManagementServerSetTitleDataAsync(
            PFEntityHandle titleEntityHandle,
            PFTitleDataManagementSetTitleDataRequest request
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
                Interop.PFTitleDataManagementSetTitleDataRequest* requestInterop = stackalloc Interop.PFTitleDataManagementSetTitleDataRequest[1];
                PFTitleDataManagementSetTitleDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFTitleDataManagementServerSetTitleDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates the key-value store of custom title settings
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This API is designed to store title specific values which are accessible only to the server. This
        /// can be used to tweak settings on game servers and Cloud Scripts without needed to update and re-deploy
        /// them. This operation is additive. If a Key does not exist in the current dataset, it will be added
        /// with the specified Value. If it already exists, the Value for that key will be overwritten with the
        /// new Value. See also ServerGetTitleInternalDataAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_DATA_LENGTH_EXCEEDED, E_PF_TOO_MANY_KEYS or any of the global PlayFab
        /// Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFTitleDataManagementServerSetTitleInternalDataAsync(
            PFEntityHandle titleEntityHandle,
            PFTitleDataManagementSetTitleDataRequest request
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
                Interop.PFTitleDataManagementSetTitleDataRequest* requestInterop = stackalloc Interop.PFTitleDataManagementSetTitleDataRequest[1];
                PFTitleDataManagementSetTitleDataRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFTitleDataManagementServerSetTitleInternalDataAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
