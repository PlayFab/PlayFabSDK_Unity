// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFEntity
    {
        /// <summary>
        /// Add inventory items. Up to 10,000 stacks of items can be added to a single inventory collection.
        /// Stack size is uncapped.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryAddInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given an entity type, entity identifier and container details, will add the specified inventory items.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryAddInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryAddInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFInventoryAddInventoryItemsResponse>> InventoryAddInventoryItemsAsync(
            PFInventoryAddInventoryItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryAddInventoryItemsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Delete an Inventory Collection. More information about Inventory Collections can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/inventory/collections
        /// </summary>
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
        public async Task<PFResult> InventoryDeleteInventoryCollectionAsync(
            PFInventoryDeleteInventoryCollectionRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryDeleteInventoryCollectionAsync(InteropHandle, request);
        }

        /// <summary>
        /// Delete inventory items
        /// </summary>
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
        public async Task<PFResult<PFInventoryDeleteInventoryItemsResponse>> InventoryDeleteInventoryItemsAsync(
            PFInventoryDeleteInventoryItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryDeleteInventoryItemsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Execute a list of Inventory Operations. A maximum list of 50 operations can be performed by a single
        /// request. There is also a limit to 300 items that can be modified/added in a single request. For example,
        /// adding a bundle with 50 items counts as 50 items modified. All operations must be done within a single
        /// inventory collection. This API has a reduced RPS compared to an individual inventory operation with
        /// Player Entities limited to 60 requests in 90 seconds.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryExecuteInventoryOperationsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Execute a list of Inventory Operations for an Entity.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryExecuteInventoryOperationsGetResultSize"/>
        /// and <see cref="PFInventoryExecuteInventoryOperationsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFInventoryExecuteInventoryOperationsResponse>> InventoryExecuteInventoryOperationsAsync(
            PFInventoryExecuteInventoryOperationsRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryExecuteInventoryOperationsAsync(InteropHandle, request);
        }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_SERVER
        /// <summary>
        /// Transfer a list of inventory items. A maximum list of 50 operations can be performed by a single
        /// request. When the response code is 202, one or more operations did not complete within the timeframe
        /// of the request. You can identify the pending operations by looking for OperationStatus = 'InProgress'.
        /// You can check on the operation status at anytime within 1 day of the request by passing the TransactionToken
        /// to the GetInventoryOperationStatus API.
        /// </summary>
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
        public async Task<PFResult<PFInventoryExecuteTransferOperationsResponse>> InventoryExecuteTransferOperationsAsync(
            PFInventoryExecuteTransferOperationsRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryExecuteTransferOperationsAsync(InteropHandle, request);
        }
#endif

        /// <summary>
        /// Get Inventory Collection Ids. Up to 50 Ids can be returned at once (or 250 with response compression
        /// enabled). You can use continuation tokens to paginate through results that return greater than the
        /// limit. It can take a few seconds for new collection Ids to show up.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryGetInventoryCollectionIdsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Get a list of Inventory Collection Ids for the specified Entity.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryGetInventoryCollectionIdsGetResultSize"/>
        /// and <see cref="PFInventoryGetInventoryCollectionIdsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFInventoryGetInventoryCollectionIdsResponse>> InventoryGetInventoryCollectionIdsAsync(
            PFInventoryGetInventoryCollectionIdsRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryGetInventoryCollectionIdsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Get current inventory items.
        /// </summary>
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
        public async Task<PFResult<PFInventoryGetInventoryItemsResponse>> InventoryGetInventoryItemsAsync(
            PFInventoryGetInventoryItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryGetInventoryItemsAsync(InteropHandle, request);
        }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_SERVER
        /// <summary>
        /// Get the status of an inventory operation using an OperationToken. You can check on the operation
        /// status at anytime within 1 day of the request by passing the TransactionToken to the this API.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryGetInventoryOperationStatusResponse.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// Get the status of an Inventory Operation using an OperationToken.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryGetInventoryOperationStatusGetResultSize"/>
        /// and <see cref="PFInventoryGetInventoryOperationStatusGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFInventoryGetInventoryOperationStatusResponse>> InventoryGetInventoryOperationStatusAsync(
            PFInventoryGetInventoryOperationStatusRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryGetInventoryOperationStatusAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Gets the access tokens.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryGetMicrosoftStoreAccessTokensResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Gets the access tokens for Microsoft Store authentication.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryGetMicrosoftStoreAccessTokensGetResultSize"/>
        /// and <see cref="PFInventoryGetMicrosoftStoreAccessTokensGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFInventoryGetMicrosoftStoreAccessTokensResponse>> InventoryGetMicrosoftStoreAccessTokensAsync(
            PFInventoryGetMicrosoftStoreAccessTokensRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryGetMicrosoftStoreAccessTokensAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Get transaction history for a player. Up to 250 Events can be returned at once. You can use continuation
        /// tokens to paginate through results that return greater than the limit. Getting transaction history
        /// has a lower RPS limit than getting a Player's inventory with Player Entities having a limit of 30
        /// requests in 300 seconds.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryGetTransactionHistoryResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Get transaction history for specified entity and collection.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryGetTransactionHistoryGetResultSize"/>
        /// and <see cref="PFInventoryGetTransactionHistoryGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFInventoryGetTransactionHistoryResponse>> InventoryGetTransactionHistoryAsync(
            PFInventoryGetTransactionHistoryRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryGetTransactionHistoryAsync(InteropHandle, request);
        }
#endif

        /// <summary>
        /// Purchase an item or bundle. Up to 10,000 stacks of items can be added to a single inventory collection.
        /// Stack size is uncapped.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryPurchaseInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Purchase a single item or bundle, paying the associated price.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryPurchaseInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryPurchaseInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFInventoryPurchaseInventoryItemsResponse>> InventoryPurchaseInventoryItemsAsync(
            PFInventoryPurchaseInventoryItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryPurchaseInventoryItemsAsync(InteropHandle, request);
        }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_IOS || UNITY_SERVER
        /// <summary>
        /// Redeem items.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryRedeemAppleAppStoreInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows and iOS.
        /// Redeem items from the Apple App Store.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryRedeemAppleAppStoreInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryRedeemAppleAppStoreInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFInventoryRedeemAppleAppStoreInventoryItemsResponse>> InventoryRedeemAppleAppStoreInventoryItemsAsync(
            PFInventoryRedeemAppleAppStoreInventoryItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryRedeemAppleAppStoreInventoryItemsAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_ANDROID || UNITY_SERVER
        /// <summary>
        /// Redeem items.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryRedeemGooglePlayInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows and Android.
        /// Redeem items from the Google Play Store.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryRedeemGooglePlayInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryRedeemGooglePlayInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFInventoryRedeemGooglePlayInventoryItemsResponse>> InventoryRedeemGooglePlayInventoryItemsAsync(
            PFInventoryRedeemGooglePlayInventoryItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryRedeemGooglePlayInventoryItemsAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Redeem items.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryRedeemMicrosoftStoreInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Redeem items from the Microsoft Store.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryRedeemMicrosoftStoreInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryRedeemMicrosoftStoreInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFInventoryRedeemMicrosoftStoreInventoryItemsResponse>> InventoryRedeemMicrosoftStoreInventoryItemsAsync(
            PFInventoryRedeemMicrosoftStoreInventoryItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryRedeemMicrosoftStoreInventoryItemsAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_SWITCH || UNITY_OUNCE || UNITY_SWITCH2 || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Redeem items.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryRedeemNintendoEShopInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Nintendo Switch, Linux, and macOS.
        /// Redeem items from the Nintendo EShop.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryRedeemNintendoEShopInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryRedeemNintendoEShopInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFInventoryRedeemNintendoEShopInventoryItemsResponse>> InventoryRedeemNintendoEShopInventoryItemsAsync(
            PFInventoryRedeemNintendoEShopInventoryItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryRedeemNintendoEShopInventoryItemsAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_PS4 || UNITY_PS5 || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Redeem items.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryRedeemPlayStationStoreInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Sony PlayStation®, Linux, and macOS.
        /// Redeem items from the PlayStation Store.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryRedeemPlayStationStoreInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryRedeemPlayStationStoreInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFInventoryRedeemPlayStationStoreInventoryItemsResponse>> InventoryRedeemPlayStationStoreInventoryItemsAsync(
            PFInventoryRedeemPlayStationStoreInventoryItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryRedeemPlayStationStoreInventoryItemsAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Redeem items.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFInventoryRedeemSteamInventoryItemsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Redeem inventory items from Steam.
        ///
        /// When the asynchronous task is complete, call <see cref="PFInventoryRedeemSteamInventoryItemsGetResultSize"/>
        /// and <see cref="PFInventoryRedeemSteamInventoryItemsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFInventoryRedeemSteamInventoryItemsResponse>> InventoryRedeemSteamInventoryItemsAsync(
            PFInventoryRedeemSteamInventoryItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryRedeemSteamInventoryItemsAsync(InteropHandle, request);
        }
#endif

        /// <summary>
        /// Subtract inventory items.
        /// </summary>
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
        public async Task<PFResult<PFInventorySubtractInventoryItemsResponse>> InventorySubtractInventoryItemsAsync(
            PFInventorySubtractInventoryItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventorySubtractInventoryItemsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Transfer inventory items. When transferring across collections, a 202 response indicates that the
        /// transfer did not complete within the timeframe of the request. You can identify the pending operations
        /// by looking for OperationStatus = 'InProgress'. You can check on the operation status at anytime within
        /// 1 day of the request by passing the TransactionToken to the GetInventoryOperationStatus API. More
        /// information about item transfer scenarios can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/inventory/?tabs=inventory-game-manager#transfer-inventory-items
        /// </summary>
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
        public async Task<PFResult<PFInventoryTransferInventoryItemsResponse>> InventoryTransferInventoryItemsAsync(
            PFInventoryTransferInventoryItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryTransferInventoryItemsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Update inventory items
        /// </summary>
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
        public async Task<PFResult<PFInventoryUpdateInventoryItemsResponse>> InventoryUpdateInventoryItemsAsync(
            PFInventoryUpdateInventoryItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFInventory.PFInventoryUpdateInventoryItemsAsync(InteropHandle, request);
        }
    }
}
