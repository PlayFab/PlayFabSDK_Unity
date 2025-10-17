// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFInventory
    {

        /// <summary>
        /// Add inventory items. Up to 10,000 stacks of items can be added to a single inventory collection.
        /// Stack size is uncapped.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryAddInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given an entity type, entity identifier and container details, will add the specified inventory items.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryAddInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryAddInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryAddInventoryItemsResponse>> PFInventoryAddInventoryItemsAsync(
            PFEntityHandle entityHandle,
            PFInventoryAddInventoryItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryAddInventoryItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryAddInventoryItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryAddInventoryItemsResponse* result = null;

                    hr = Interop.Methods.PFInventoryAddInventoryItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryAddInventoryItemsRequest* requestInterop = stackalloc Interop.PFInventoryAddInventoryItemsRequest[1];
                PFInventoryAddInventoryItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryAddInventoryItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Delete an Inventory Collection. More information about Inventory Collections can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/inventory/collections
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Delete an Inventory Collection by the specified Id for an Entity.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_INVENTORY_COLLECTION_DELETION_DISALLOWED or any of the global PlayFab
        /// Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFInventoryDeleteInventoryCollectionAsync(
            PFEntityHandle entityHandle,
            PFInventoryDeleteInventoryCollectionRequest request
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
                Interop.PFInventoryDeleteInventoryCollectionRequest* requestInterop = stackalloc Interop.PFInventoryDeleteInventoryCollectionRequest[1];
                PFInventoryDeleteInventoryCollectionRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryDeleteInventoryCollectionAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Delete inventory items
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryDeleteInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given an entity type, entity identifier and container details, will delete the entity's inventory
        /// items.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryDeleteInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryDeleteInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryDeleteInventoryItemsResponse>> PFInventoryDeleteInventoryItemsAsync(
            PFEntityHandle entityHandle,
            PFInventoryDeleteInventoryItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryDeleteInventoryItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryDeleteInventoryItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryDeleteInventoryItemsResponse* result = null;

                    hr = Interop.Methods.PFInventoryDeleteInventoryItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryDeleteInventoryItemsRequest* requestInterop = stackalloc Interop.PFInventoryDeleteInventoryItemsRequest[1];
                PFInventoryDeleteInventoryItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryDeleteInventoryItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Execute a list of Inventory Operations. A maximum list of 50 operations can be performed by a single
        /// request. There is also a limit to 300 items that can be modified/added in a single request. For example,
        /// adding a bundle with 50 items counts as 50 items modified. All operations must be done within a single
        /// inventory collection. This API has a reduced RPS compared to an individual inventory operation with
        /// Player Entities limited to 60 requests in 90 seconds.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryExecuteInventoryOperationsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Execute a list of Inventory Operations for an Entity.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryExecuteInventoryOperationsGetResultSize"/>
        /// and <see cref="PFInventoryExecuteInventoryOperationsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryExecuteInventoryOperationsResponse>> PFInventoryExecuteInventoryOperationsAsync(
            PFEntityHandle entityHandle,
            PFInventoryExecuteInventoryOperationsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryExecuteInventoryOperationsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryExecuteInventoryOperationsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryExecuteInventoryOperationsResponse* result = null;

                    hr = Interop.Methods.PFInventoryExecuteInventoryOperationsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryExecuteInventoryOperationsRequest* requestInterop = stackalloc Interop.PFInventoryExecuteInventoryOperationsRequest[1];
                PFInventoryExecuteInventoryOperationsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryExecuteInventoryOperationsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Transfer a list of inventory items. A maximum list of 50 operations can be performed by a single
        /// request. When the response code is 202, one or more operations did not complete within the timeframe
        /// of the request. You can identify the pending operations by looking for OperationStatus = 'InProgress'.
        /// You can check on the operation status at anytime within 1 day of the request by passing the TransactionToken
        /// to the GetInventoryOperationStatus API.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryExecuteTransferOperationsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// Transfer the specified list of inventory items of an entity's container Id to another entity's container
        /// Id.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryExecuteTransferOperationsGetResultSize"/>
        /// and <see cref="PFInventoryExecuteTransferOperationsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryExecuteTransferOperationsResponse>> PFInventoryExecuteTransferOperationsAsync(
            PFEntityHandle entityHandle,
            PFInventoryExecuteTransferOperationsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryExecuteTransferOperationsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryExecuteTransferOperationsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryExecuteTransferOperationsResponse* result = null;

                    hr = Interop.Methods.PFInventoryExecuteTransferOperationsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryExecuteTransferOperationsRequest* requestInterop = stackalloc Interop.PFInventoryExecuteTransferOperationsRequest[1];
                PFInventoryExecuteTransferOperationsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryExecuteTransferOperationsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Get Inventory Collection Ids. Up to 50 Ids can be returned at once (or 250 with response compression
        /// enabled). You can use continuation tokens to paginate through results that return greater than the
        /// limit. It can take a few seconds for new collection Ids to show up.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryGetInventoryCollectionIdsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Get a list of Inventory Collection Ids for the specified Entity.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryGetInventoryCollectionIdsGetResultSize"/>
        /// and <see cref="PFInventoryGetInventoryCollectionIdsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryGetInventoryCollectionIdsResponse>> PFInventoryGetInventoryCollectionIdsAsync(
            PFEntityHandle entityHandle,
            PFInventoryGetInventoryCollectionIdsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryGetInventoryCollectionIdsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryGetInventoryCollectionIdsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryGetInventoryCollectionIdsResponse* result = null;

                    hr = Interop.Methods.PFInventoryGetInventoryCollectionIdsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryGetInventoryCollectionIdsRequest* requestInterop = stackalloc Interop.PFInventoryGetInventoryCollectionIdsRequest[1];
                PFInventoryGetInventoryCollectionIdsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryGetInventoryCollectionIdsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Get current inventory items.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryGetInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given an entity type, entity identifier and container details, will get the entity's inventory items.
        /// .
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryGetInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryGetInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryGetInventoryItemsResponse>> PFInventoryGetInventoryItemsAsync(
            PFEntityHandle entityHandle,
            PFInventoryGetInventoryItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryGetInventoryItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryGetInventoryItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryGetInventoryItemsResponse* result = null;

                    hr = Interop.Methods.PFInventoryGetInventoryItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryGetInventoryItemsRequest* requestInterop = stackalloc Interop.PFInventoryGetInventoryItemsRequest[1];
                PFInventoryGetInventoryItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryGetInventoryItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Get the status of an inventory operation using an OperationToken. You can check on the operation
        /// status at anytime within 1 day of the request by passing the TransactionToken to the this API.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryGetInventoryOperationStatusResponse.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// Get the status of an Inventory Operation using an OperationToken.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryGetInventoryOperationStatusGetResultSize"/>
        /// and <see cref="PFInventoryGetInventoryOperationStatusGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryGetInventoryOperationStatusResponse>> PFInventoryGetInventoryOperationStatusAsync(
            PFEntityHandle entityHandle,
            PFInventoryGetInventoryOperationStatusRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryGetInventoryOperationStatusResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryGetInventoryOperationStatusGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryGetInventoryOperationStatusResponse* result = null;

                    hr = Interop.Methods.PFInventoryGetInventoryOperationStatusGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryGetInventoryOperationStatusRequest* requestInterop = stackalloc Interop.PFInventoryGetInventoryOperationStatusRequest[1];
                PFInventoryGetInventoryOperationStatusRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryGetInventoryOperationStatusAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Gets the access tokens.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryGetMicrosoftStoreAccessTokensResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Gets the access tokens for Microsoft Store authentication.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryGetMicrosoftStoreAccessTokensGetResultSize"/>
        /// and <see cref="PFInventoryGetMicrosoftStoreAccessTokensGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryGetMicrosoftStoreAccessTokensResponse>> PFInventoryGetMicrosoftStoreAccessTokensAsync(
            PFEntityHandle entityHandle,
            PFInventoryGetMicrosoftStoreAccessTokensRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryGetMicrosoftStoreAccessTokensResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryGetMicrosoftStoreAccessTokensGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryGetMicrosoftStoreAccessTokensResponse* result = null;

                    hr = Interop.Methods.PFInventoryGetMicrosoftStoreAccessTokensGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryGetMicrosoftStoreAccessTokensRequest* requestInterop = stackalloc Interop.PFInventoryGetMicrosoftStoreAccessTokensRequest[1];
                PFInventoryGetMicrosoftStoreAccessTokensRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryGetMicrosoftStoreAccessTokensAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Get transaction history for a player. Up to 250 Events can be returned at once. You can use continuation
        /// tokens to paginate through results that return greater than the limit. Getting transaction history
        /// has a lower RPS limit than getting a Player's inventory with Player Entities having a limit of 30
        /// requests in 300 seconds.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryGetTransactionHistoryResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Get transaction history for specified entity and collection.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryGetTransactionHistoryGetResultSize"/>
        /// and <see cref="PFInventoryGetTransactionHistoryGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryGetTransactionHistoryResponse>> PFInventoryGetTransactionHistoryAsync(
            PFEntityHandle entityHandle,
            PFInventoryGetTransactionHistoryRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryGetTransactionHistoryResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryGetTransactionHistoryGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryGetTransactionHistoryResponse* result = null;

                    hr = Interop.Methods.PFInventoryGetTransactionHistoryGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryGetTransactionHistoryRequest* requestInterop = stackalloc Interop.PFInventoryGetTransactionHistoryRequest[1];
                PFInventoryGetTransactionHistoryRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryGetTransactionHistoryAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Purchase an item or bundle. Up to 10,000 stacks of items can be added to a single inventory collection.
        /// Stack size is uncapped.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryPurchaseInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Purchase a single item or bundle, paying the associated price.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryPurchaseInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryPurchaseInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryPurchaseInventoryItemsResponse>> PFInventoryPurchaseInventoryItemsAsync(
            PFEntityHandle entityHandle,
            PFInventoryPurchaseInventoryItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryPurchaseInventoryItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryPurchaseInventoryItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryPurchaseInventoryItemsResponse* result = null;

                    hr = Interop.Methods.PFInventoryPurchaseInventoryItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryPurchaseInventoryItemsRequest* requestInterop = stackalloc Interop.PFInventoryPurchaseInventoryItemsRequest[1];
                PFInventoryPurchaseInventoryItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryPurchaseInventoryItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryRedeemAppleAppStoreInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows and iOS.
        /// Redeem items from the Apple App Store.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryRedeemAppleAppStoreInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryRedeemAppleAppStoreInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryRedeemAppleAppStoreInventoryItemsResponse>> PFInventoryRedeemAppleAppStoreInventoryItemsAsync(
            PFEntityHandle entityHandle,
            PFInventoryRedeemAppleAppStoreInventoryItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryRedeemAppleAppStoreInventoryItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryRedeemAppleAppStoreInventoryItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryRedeemAppleAppStoreInventoryItemsResponse* result = null;

                    hr = Interop.Methods.PFInventoryRedeemAppleAppStoreInventoryItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryRedeemAppleAppStoreInventoryItemsRequest* requestInterop = stackalloc Interop.PFInventoryRedeemAppleAppStoreInventoryItemsRequest[1];
                PFInventoryRedeemAppleAppStoreInventoryItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryRedeemAppleAppStoreInventoryItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryRedeemGooglePlayInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows and Android.
        /// Redeem items from the Google Play Store.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryRedeemGooglePlayInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryRedeemGooglePlayInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryRedeemGooglePlayInventoryItemsResponse>> PFInventoryRedeemGooglePlayInventoryItemsAsync(
            PFEntityHandle entityHandle,
            PFInventoryRedeemGooglePlayInventoryItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryRedeemGooglePlayInventoryItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryRedeemGooglePlayInventoryItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryRedeemGooglePlayInventoryItemsResponse* result = null;

                    hr = Interop.Methods.PFInventoryRedeemGooglePlayInventoryItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryRedeemGooglePlayInventoryItemsRequest* requestInterop = stackalloc Interop.PFInventoryRedeemGooglePlayInventoryItemsRequest[1];
                PFInventoryRedeemGooglePlayInventoryItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryRedeemGooglePlayInventoryItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryRedeemMicrosoftStoreInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Redeem items from the Microsoft Store.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryRedeemMicrosoftStoreInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryRedeemMicrosoftStoreInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryRedeemMicrosoftStoreInventoryItemsResponse>> PFInventoryRedeemMicrosoftStoreInventoryItemsAsync(
            PFEntityHandle entityHandle,
            PFInventoryRedeemMicrosoftStoreInventoryItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryRedeemMicrosoftStoreInventoryItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryRedeemMicrosoftStoreInventoryItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryRedeemMicrosoftStoreInventoryItemsResponse* result = null;

                    hr = Interop.Methods.PFInventoryRedeemMicrosoftStoreInventoryItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryRedeemMicrosoftStoreInventoryItemsRequest* requestInterop = stackalloc Interop.PFInventoryRedeemMicrosoftStoreInventoryItemsRequest[1];
                PFInventoryRedeemMicrosoftStoreInventoryItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryRedeemMicrosoftStoreInventoryItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryRedeemNintendoEShopInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Nintendo Switch, Linux, and macOS.
        /// Redeem items from the Nintendo EShop.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryRedeemNintendoEShopInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryRedeemNintendoEShopInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryRedeemNintendoEShopInventoryItemsResponse>> PFInventoryRedeemNintendoEShopInventoryItemsAsync(
            PFEntityHandle entityHandle,
            PFInventoryRedeemNintendoEShopInventoryItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryRedeemNintendoEShopInventoryItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryRedeemNintendoEShopInventoryItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryRedeemNintendoEShopInventoryItemsResponse* result = null;

                    hr = Interop.Methods.PFInventoryRedeemNintendoEShopInventoryItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryRedeemNintendoEShopInventoryItemsRequest* requestInterop = stackalloc Interop.PFInventoryRedeemNintendoEShopInventoryItemsRequest[1];
                PFInventoryRedeemNintendoEShopInventoryItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryRedeemNintendoEShopInventoryItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryRedeemPlayStationStoreInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Sony PlayStation®, Linux, and macOS.
        /// Redeem items from the PlayStation Store.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryRedeemPlayStationStoreInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryRedeemPlayStationStoreInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryRedeemPlayStationStoreInventoryItemsResponse>> PFInventoryRedeemPlayStationStoreInventoryItemsAsync(
            PFEntityHandle entityHandle,
            PFInventoryRedeemPlayStationStoreInventoryItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryRedeemPlayStationStoreInventoryItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryRedeemPlayStationStoreInventoryItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryRedeemPlayStationStoreInventoryItemsResponse* result = null;

                    hr = Interop.Methods.PFInventoryRedeemPlayStationStoreInventoryItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryRedeemPlayStationStoreInventoryItemsRequest* requestInterop = stackalloc Interop.PFInventoryRedeemPlayStationStoreInventoryItemsRequest[1];
                PFInventoryRedeemPlayStationStoreInventoryItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryRedeemPlayStationStoreInventoryItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Redeem items.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryRedeemSteamInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Redeem inventory items from Steam.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryRedeemSteamInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryRedeemSteamInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryRedeemSteamInventoryItemsResponse>> PFInventoryRedeemSteamInventoryItemsAsync(
            PFEntityHandle entityHandle,
            PFInventoryRedeemSteamInventoryItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryRedeemSteamInventoryItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryRedeemSteamInventoryItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryRedeemSteamInventoryItemsResponse* result = null;

                    hr = Interop.Methods.PFInventoryRedeemSteamInventoryItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryRedeemSteamInventoryItemsRequest* requestInterop = stackalloc Interop.PFInventoryRedeemSteamInventoryItemsRequest[1];
                PFInventoryRedeemSteamInventoryItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryRedeemSteamInventoryItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Subtract inventory items.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventorySubtractInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given an entity type, entity identifier and container details, will subtract the specified inventory
        /// items. .
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventorySubtractInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventorySubtractInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventorySubtractInventoryItemsResponse>> PFInventorySubtractInventoryItemsAsync(
            PFEntityHandle entityHandle,
            PFInventorySubtractInventoryItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventorySubtractInventoryItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventorySubtractInventoryItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventorySubtractInventoryItemsResponse* result = null;

                    hr = Interop.Methods.PFInventorySubtractInventoryItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventorySubtractInventoryItemsRequest* requestInterop = stackalloc Interop.PFInventorySubtractInventoryItemsRequest[1];
                PFInventorySubtractInventoryItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventorySubtractInventoryItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Transfer inventory items. When transferring across collections, a 202 response indicates that the
        /// transfer did not complete within the timeframe of the request. You can identify the pending operations
        /// by looking for OperationStatus = 'InProgress'. You can check on the operation status at anytime within
        /// 1 day of the request by passing the TransactionToken to the GetInventoryOperationStatus API. More
        /// information about item transfer scenarios can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/inventory/?tabs=inventory-game-manager#transfer-inventory-items
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryTransferInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Transfer the specified inventory items of an entity's container Id to another entity's container
        /// Id.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryTransferInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryTransferInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryTransferInventoryItemsResponse>> PFInventoryTransferInventoryItemsAsync(
            PFEntityHandle entityHandle,
            PFInventoryTransferInventoryItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryTransferInventoryItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryTransferInventoryItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryTransferInventoryItemsResponse* result = null;

                    hr = Interop.Methods.PFInventoryTransferInventoryItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryTransferInventoryItemsRequest* requestInterop = stackalloc Interop.PFInventoryTransferInventoryItemsRequest[1];
                PFInventoryTransferInventoryItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryTransferInventoryItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Update inventory items
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryUpdateInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given an entity type, entity identifier and container details, will update the entity's inventory
        /// items.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryUpdateInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryUpdateInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFInventoryUpdateInventoryItemsResponse>> PFInventoryUpdateInventoryItemsAsync(
            PFEntityHandle entityHandle,
            PFInventoryUpdateInventoryItemsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFInventoryUpdateInventoryItemsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFInventoryUpdateInventoryItemsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFInventoryUpdateInventoryItemsResponse* result = null;

                    hr = Interop.Methods.PFInventoryUpdateInventoryItemsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFInventoryUpdateInventoryItemsRequest* requestInterop = stackalloc Interop.PFInventoryUpdateInventoryItemsRequest[1];
                PFInventoryUpdateInventoryItemsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFInventoryUpdateInventoryItemsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
