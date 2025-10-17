// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFCatalog
    {

        /// <summary>
        /// Creates a new item in the working catalog using provided metadata. Note: SAS tokens provided are
        /// valid for 1 hour.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogCreateDraftItemResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// The item will not be published to the public catalog until the PublishItem API is called for the
        /// item.
        ///
        /// When the asynchronous task is complete, call <see cref="PFCatalogCreateDraftItemGetResultSize"/>
        /// and <see cref="PFCatalogCreateDraftItemGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCatalogCreateDraftItemResponse>> PFCatalogCreateDraftItemAsync(
            PFEntityHandle entityHandle,
            PFCatalogCreateDraftItemRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCatalogCreateDraftItemResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCatalogCreateDraftItemGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCatalogCreateDraftItemResponse* result = null;

                    hr = Interop.Methods.PFCatalogCreateDraftItemGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCatalogCreateDraftItemRequest* requestInterop = stackalloc Interop.PFCatalogCreateDraftItemRequest[1];
                PFCatalogCreateDraftItemRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogCreateDraftItemAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Creates one or more upload URLs which can be used by the client to upload raw file data. Content
        /// URls and uploaded content will be garbage collected after 24 hours if not attached to a draft or published
        /// item. Detailed pricing info around uploading content can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/pricing/meters/catalog-meters
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogCreateUploadUrlsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Upload URLs point to Azure Blobs; clients must follow the Microsoft Azure Storage Blob Service REST
        /// API pattern for uploading content. The response contains upload URLs and IDs for each file. The IDs
        /// and URLs returned must be added to the item metadata and committed using the CreateDraftItem or UpdateDraftItem
        /// Item APIs.
        ///
        /// When the asynchronous task is complete, call <see cref="PFCatalogCreateUploadUrlsGetResultSize"/>
        /// and <see cref="PFCatalogCreateUploadUrlsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCatalogCreateUploadUrlsResponse>> PFCatalogCreateUploadUrlsAsync(
            PFEntityHandle entityHandle,
            PFCatalogCreateUploadUrlsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCatalogCreateUploadUrlsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCatalogCreateUploadUrlsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCatalogCreateUploadUrlsResponse* result = null;

                    hr = Interop.Methods.PFCatalogCreateUploadUrlsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCatalogCreateUploadUrlsRequest* requestInterop = stackalloc Interop.PFCatalogCreateUploadUrlsRequest[1];
                PFCatalogCreateUploadUrlsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogCreateUploadUrlsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Deletes all reviews, helpfulness votes, and ratings submitted by the entity specified.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_PROFILE_DOES_NOT_EXIST or any of the global PlayFab Service errors.
        /// See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFCatalogDeleteEntityItemReviewsAsync(
            PFEntityHandle entityHandle,
            PFCatalogDeleteEntityItemReviewsRequest request
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
                Interop.PFCatalogDeleteEntityItemReviewsRequest* requestInterop = stackalloc Interop.PFCatalogDeleteEntityItemReviewsRequest[1];
                PFCatalogDeleteEntityItemReviewsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogDeleteEntityItemReviewsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Removes an item from working catalog and all published versions from the public catalog.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_DATABASE_THROUGHPUT_EXCEEDED, E_PF_ITEM_NOT_FOUND or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFCatalogDeleteItemAsync(
            PFEntityHandle entityHandle,
            PFCatalogDeleteItemRequest request
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
                Interop.PFCatalogDeleteItemRequest* requestInterop = stackalloc Interop.PFCatalogDeleteItemRequest[1];
                PFCatalogDeleteItemRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogDeleteItemAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Gets the configuration for the catalog. Only Title Entities can call this API. There is a limit of
        /// 100 requests in 10 seconds for this API. More information about the Catalog Config can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/settings
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetCatalogConfigResponse.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetCatalogConfigGetResultSize"/>
        /// and <see cref="PFCatalogGetCatalogConfigGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCatalogGetCatalogConfigResponse>> PFCatalogGetCatalogConfigAsync(
            PFEntityHandle entityHandle,
            PFCatalogGetCatalogConfigRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCatalogGetCatalogConfigResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCatalogGetCatalogConfigGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCatalogGetCatalogConfigResponse* result = null;

                    hr = Interop.Methods.PFCatalogGetCatalogConfigGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCatalogGetCatalogConfigRequest* requestInterop = stackalloc Interop.PFCatalogGetCatalogConfigRequest[1];
                PFCatalogGetCatalogConfigRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogGetCatalogConfigAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves an item from the working catalog. This item represents the current working state of the
        /// item. GetDraftItem does not work off a cache of the Catalog and should be used when trying to get
        /// recent item updates. However, please note that item references data is cached and may take a few moments
        /// for changes to propagate. Note: SAS tokens provided are valid for 1 hour.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetDraftItemResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetDraftItemGetResultSize"/> and
        /// <see cref="PFCatalogGetDraftItemGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCatalogGetDraftItemResponse>> PFCatalogGetDraftItemAsync(
            PFEntityHandle entityHandle,
            PFCatalogGetDraftItemRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCatalogGetDraftItemResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCatalogGetDraftItemGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCatalogGetDraftItemResponse* result = null;

                    hr = Interop.Methods.PFCatalogGetDraftItemGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCatalogGetDraftItemRequest* requestInterop = stackalloc Interop.PFCatalogGetDraftItemRequest[1];
                PFCatalogGetDraftItemRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogGetDraftItemAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves a paginated list of the items from the draft catalog. Up to 50 IDs can be retrieved in
        /// a single request. GetDraftItems does not work off a cache of the Catalog and should be used when trying
        /// to get recent item updates. Note: SAS tokens provided are valid for 1 hour.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetDraftItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetDraftItemsGetResultSize"/> and
        /// <see cref="PFCatalogGetDraftItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCatalogGetDraftItemsResponse>> PFCatalogGetDraftItemsAsync(
            PFEntityHandle entityHandle,
            PFCatalogGetDraftItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCatalogGetDraftItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCatalogGetDraftItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCatalogGetDraftItemsResponse* result = null;

                    hr = Interop.Methods.PFCatalogGetDraftItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCatalogGetDraftItemsRequest* requestInterop = stackalloc Interop.PFCatalogGetDraftItemsRequest[1];
                PFCatalogGetDraftItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogGetDraftItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves a paginated list of the items from the draft catalog created by the Entity. Up to 50 items
        /// can be returned at once. You can use continuation tokens to paginate through results that return greater
        /// than the limit. GetEntityDraftItems does not work off a cache of the Catalog and should be used when
        /// trying to get recent item updates.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetEntityDraftItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetEntityDraftItemsGetResultSize"/>
        /// and <see cref="PFCatalogGetEntityDraftItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCatalogGetEntityDraftItemsResponse>> PFCatalogGetEntityDraftItemsAsync(
            PFEntityHandle entityHandle,
            PFCatalogGetEntityDraftItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCatalogGetEntityDraftItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCatalogGetEntityDraftItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCatalogGetEntityDraftItemsResponse* result = null;

                    hr = Interop.Methods.PFCatalogGetEntityDraftItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCatalogGetEntityDraftItemsRequest* requestInterop = stackalloc Interop.PFCatalogGetEntityDraftItemsRequest[1];
                PFCatalogGetEntityDraftItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogGetEntityDraftItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Gets the submitted review for the specified item by the authenticated entity. Individual ratings
        /// and reviews data update in near real time with delays within a few seconds.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetEntityItemReviewResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetEntityItemReviewGetResultSize"/>
        /// and <see cref="PFCatalogGetEntityItemReviewGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCatalogGetEntityItemReviewResponse>> PFCatalogGetEntityItemReviewAsync(
            PFEntityHandle entityHandle,
            PFCatalogGetEntityItemReviewRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCatalogGetEntityItemReviewResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCatalogGetEntityItemReviewGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCatalogGetEntityItemReviewResponse* result = null;

                    hr = Interop.Methods.PFCatalogGetEntityItemReviewGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCatalogGetEntityItemReviewRequest* requestInterop = stackalloc Interop.PFCatalogGetEntityItemReviewRequest[1];
                PFCatalogGetEntityItemReviewRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogGetEntityItemReviewAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves an item from the public catalog. GetItem does not work off a cache of the Catalog and should
        /// be used when trying to get recent item updates. However, please note that item references data is
        /// cached and may take a few moments for changes to propagate.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetItemResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetItemGetResultSize"/> and <see
        /// cref="PFCatalogGetItemGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCatalogGetItemResponse>> PFCatalogGetItemAsync(
            PFEntityHandle entityHandle,
            PFCatalogGetItemRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCatalogGetItemResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCatalogGetItemGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCatalogGetItemResponse* result = null;

                    hr = Interop.Methods.PFCatalogGetItemGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCatalogGetItemRequest* requestInterop = stackalloc Interop.PFCatalogGetItemRequest[1];
                PFCatalogGetItemRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogGetItemAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Search for a given item and return a set of bundles and stores containing the item. Up to 50 items
        /// can be returned at once. You can use continuation tokens to paginate through results that return greater
        /// than the limit. This API is intended for tooling/automation scenarios and has a reduced RPS with Player
        /// Entities limited to 30 requests in 300 seconds and Title Entities limited to 100 requests in 10 seconds.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetItemContainersResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given an item, return a set of bundles and stores containing the item.
        ///
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetItemContainersGetResultSize"/>
        /// and <see cref="PFCatalogGetItemContainersGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCatalogGetItemContainersResponse>> PFCatalogGetItemContainersAsync(
            PFEntityHandle entityHandle,
            PFCatalogGetItemContainersRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCatalogGetItemContainersResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCatalogGetItemContainersGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCatalogGetItemContainersResponse* result = null;

                    hr = Interop.Methods.PFCatalogGetItemContainersGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCatalogGetItemContainersRequest* requestInterop = stackalloc Interop.PFCatalogGetItemContainersRequest[1];
                PFCatalogGetItemContainersRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogGetItemContainersAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Gets the moderation state for an item, including the concern category and string reason. More information
        /// about moderation states can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/ugc/moderation
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetItemModerationStateResponse.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetItemModerationStateGetResultSize"/>
        /// and <see cref="PFCatalogGetItemModerationStateGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCatalogGetItemModerationStateResponse>> PFCatalogGetItemModerationStateAsync(
            PFEntityHandle entityHandle,
            PFCatalogGetItemModerationStateRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCatalogGetItemModerationStateResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCatalogGetItemModerationStateGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCatalogGetItemModerationStateResponse* result = null;

                    hr = Interop.Methods.PFCatalogGetItemModerationStateGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCatalogGetItemModerationStateRequest* requestInterop = stackalloc Interop.PFCatalogGetItemModerationStateRequest[1];
                PFCatalogGetItemModerationStateRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogGetItemModerationStateAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Gets the status of a publish of an item.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetItemPublishStatusResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetItemPublishStatusGetResultSize"/>
        /// and <see cref="PFCatalogGetItemPublishStatusGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCatalogGetItemPublishStatusResponse>> PFCatalogGetItemPublishStatusAsync(
            PFEntityHandle entityHandle,
            PFCatalogGetItemPublishStatusRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCatalogGetItemPublishStatusResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCatalogGetItemPublishStatusGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCatalogGetItemPublishStatusResponse* result = null;

                    hr = Interop.Methods.PFCatalogGetItemPublishStatusGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCatalogGetItemPublishStatusRequest* requestInterop = stackalloc Interop.PFCatalogGetItemPublishStatusRequest[1];
                PFCatalogGetItemPublishStatusRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogGetItemPublishStatusAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Get a paginated set of reviews associated with the specified item. Individual ratings and reviews
        /// data update in near real time with delays within a few seconds.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetItemReviewsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetItemReviewsGetResultSize"/> and
        /// <see cref="PFCatalogGetItemReviewsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCatalogGetItemReviewsResponse>> PFCatalogGetItemReviewsAsync(
            PFEntityHandle entityHandle,
            PFCatalogGetItemReviewsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCatalogGetItemReviewsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCatalogGetItemReviewsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCatalogGetItemReviewsResponse* result = null;

                    hr = Interop.Methods.PFCatalogGetItemReviewsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCatalogGetItemReviewsRequest* requestInterop = stackalloc Interop.PFCatalogGetItemReviewsRequest[1];
                PFCatalogGetItemReviewsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogGetItemReviewsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Get a summary of all ratings and reviews associated with the specified item. Summary ratings data
        /// is cached with update data coming within 15 minutes.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetItemReviewSummaryResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetItemReviewSummaryGetResultSize"/>
        /// and <see cref="PFCatalogGetItemReviewSummaryGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCatalogGetItemReviewSummaryResponse>> PFCatalogGetItemReviewSummaryAsync(
            PFEntityHandle entityHandle,
            PFCatalogGetItemReviewSummaryRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCatalogGetItemReviewSummaryResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCatalogGetItemReviewSummaryGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCatalogGetItemReviewSummaryResponse* result = null;

                    hr = Interop.Methods.PFCatalogGetItemReviewSummaryGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCatalogGetItemReviewSummaryRequest* requestInterop = stackalloc Interop.PFCatalogGetItemReviewSummaryRequest[1];
                PFCatalogGetItemReviewSummaryRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogGetItemReviewSummaryAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves items from the public catalog. Up to 50 items can be returned at once. GetItems does not
        /// work off a cache of the Catalog and should be used when trying to get recent item updates. However,
        /// please note that item references data is cached and may take a few moments for changes to propagate.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetItemsGetResultSize"/> and <see
        /// cref="PFCatalogGetItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCatalogGetItemsResponse>> PFCatalogGetItemsAsync(
            PFEntityHandle entityHandle,
            PFCatalogGetItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCatalogGetItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCatalogGetItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCatalogGetItemsResponse* result = null;

                    hr = Interop.Methods.PFCatalogGetItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCatalogGetItemsRequest* requestInterop = stackalloc Interop.PFCatalogGetItemsRequest[1];
                PFCatalogGetItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogGetItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Initiates a publish of an item from the working catalog to the public catalog. You can use the GetItemPublishStatus
        /// API to track the state of the item publish.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// The call kicks off a workflow to publish the item to the public catalog. The Publish Status API should
        /// be used to monitor the publish job.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_DATABASE_THROUGHPUT_EXCEEDED, E_PF_ITEM_NOT_FOUND or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFCatalogPublishDraftItemAsync(
            PFEntityHandle entityHandle,
            PFCatalogPublishDraftItemRequest request
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
                Interop.PFCatalogPublishDraftItemRequest* requestInterop = stackalloc Interop.PFCatalogPublishDraftItemRequest[1];
                PFCatalogPublishDraftItemRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogPublishDraftItemAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Submit a report for an item, indicating in what way the item is inappropriate.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_DATABASE_THROUGHPUT_EXCEEDED, E_PF_ITEM_NOT_FOUND or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFCatalogReportItemAsync(
            PFEntityHandle entityHandle,
            PFCatalogReportItemRequest request
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
                Interop.PFCatalogReportItemRequest* requestInterop = stackalloc Interop.PFCatalogReportItemRequest[1];
                PFCatalogReportItemRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogReportItemAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Submit a report for a review
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Submit a report for an inappropriate review, allowing the submitting user to specify their concern.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_DATABASE_THROUGHPUT_EXCEEDED or any of the global PlayFab Service errors.
        /// See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFCatalogReportItemReviewAsync(
            PFEntityHandle entityHandle,
            PFCatalogReportItemReviewRequest request
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
                Interop.PFCatalogReportItemReviewRequest* requestInterop = stackalloc Interop.PFCatalogReportItemReviewRequest[1];
                PFCatalogReportItemReviewRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogReportItemReviewAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Creates or updates a review for the specified item. More information around the caching surrounding
        /// item ratings and reviews can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/ratings#ratings-design-and-caching
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_DATABASE_THROUGHPUT_EXCEEDED, E_PF_ITEM_NOT_FOUND or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFCatalogReviewItemAsync(
            PFEntityHandle entityHandle,
            PFCatalogReviewItemRequest request
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
                Interop.PFCatalogReviewItemRequest* requestInterop = stackalloc Interop.PFCatalogReviewItemRequest[1];
                PFCatalogReviewItemRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogReviewItemAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Executes a search against the public catalog using the provided search parameters and returns a set
        /// of paginated results. SearchItems uses a cache of the catalog with item updates taking up to a few
        /// minutes to propagate. You should use the GetItem API for when trying to immediately get recent item
        /// updates. More information about the Search API can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/search
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogSearchItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogSearchItemsGetResultSize"/> and
        /// <see cref="PFCatalogSearchItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCatalogSearchItemsResponse>> PFCatalogSearchItemsAsync(
            PFEntityHandle entityHandle,
            PFCatalogSearchItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCatalogSearchItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCatalogSearchItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCatalogSearchItemsResponse* result = null;

                    hr = Interop.Methods.PFCatalogSearchItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCatalogSearchItemsRequest* requestInterop = stackalloc Interop.PFCatalogSearchItemsRequest[1];
                PFCatalogSearchItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogSearchItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Sets the moderation state for an item, including the concern category and string reason. More information
        /// about moderation states can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/ugc/moderation
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_DATABASE_THROUGHPUT_EXCEEDED, E_PF_ITEM_NOT_FOUND or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFCatalogSetItemModerationStateAsync(
            PFEntityHandle entityHandle,
            PFCatalogSetItemModerationStateRequest request
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
                Interop.PFCatalogSetItemModerationStateRequest* requestInterop = stackalloc Interop.PFCatalogSetItemModerationStateRequest[1];
                PFCatalogSetItemModerationStateRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogSetItemModerationStateAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Submit a vote for a review, indicating whether the review was helpful or unhelpful.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_DATABASE_THROUGHPUT_EXCEEDED or any of the global PlayFab Service errors.
        /// See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFCatalogSubmitItemReviewVoteAsync(
            PFEntityHandle entityHandle,
            PFCatalogSubmitItemReviewVoteRequest request
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
                Interop.PFCatalogSubmitItemReviewVoteRequest* requestInterop = stackalloc Interop.PFCatalogSubmitItemReviewVoteRequest[1];
                PFCatalogSubmitItemReviewVoteRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogSubmitItemReviewVoteAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Submit a request to takedown one or more reviews.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// Submit a request to takedown one or more reviews, removing them from public view. Authors will still
        /// be able to see their reviews after being taken down.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_DATABASE_THROUGHPUT_EXCEEDED, E_PF_ITEM_NOT_FOUND or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFCatalogTakedownItemReviewsAsync(
            PFEntityHandle entityHandle,
            PFCatalogTakedownItemReviewsRequest request
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
                Interop.PFCatalogTakedownItemReviewsRequest* requestInterop = stackalloc Interop.PFCatalogTakedownItemReviewsRequest[1];
                PFCatalogTakedownItemReviewsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogTakedownItemReviewsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates the configuration for the catalog. Only Title Entities can call this API. There is a limit
        /// of 10 requests in 10 seconds for this API. More information about the Catalog Config can be found
        /// here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/settings
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_BILLING_INFORMATION_REQUIRED, E_PF_CATALOG_CONFIG_INVALID, E_PF_INVALID_ENTITY_TYPE
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public static Task<PFResult> PFCatalogUpdateCatalogConfigAsync(
            PFEntityHandle entityHandle,
            PFCatalogUpdateCatalogConfigRequest request
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
                Interop.PFCatalogUpdateCatalogConfigRequest* requestInterop = stackalloc Interop.PFCatalogUpdateCatalogConfigRequest[1];
                PFCatalogUpdateCatalogConfigRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogUpdateCatalogConfigAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Update the metadata for an item in the working catalog. Note: SAS tokens provided are valid for 1
        /// hour.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogUpdateDraftItemResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogUpdateDraftItemGetResultSize"/>
        /// and <see cref="PFCatalogUpdateDraftItemGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFCatalogUpdateDraftItemResponse>> PFCatalogUpdateDraftItemAsync(
            PFEntityHandle entityHandle,
            PFCatalogUpdateDraftItemRequest request
        )
        {
            TaskCompletionSource<PFResult<PFCatalogUpdateDraftItemResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFCatalogUpdateDraftItemGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFCatalogUpdateDraftItemResponse* result = null;

                    hr = Interop.Methods.PFCatalogUpdateDraftItemGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFCatalogUpdateDraftItemRequest* requestInterop = stackalloc Interop.PFCatalogUpdateDraftItemRequest[1];
                PFCatalogUpdateDraftItemRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFCatalogUpdateDraftItemAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
