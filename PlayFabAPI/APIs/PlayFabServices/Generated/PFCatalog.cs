// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFEntity
    {
        /// <summary>
        /// Creates a new item in the working catalog using provided metadata. Note: SAS tokens provided are
        /// valid for 1 hour.
        /// </summary>
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
        public async Task<PFResult<PFCatalogCreateDraftItemResponse>> CatalogCreateDraftItemAsync(
            PFCatalogCreateDraftItemRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogCreateDraftItemAsync(InteropHandle, request);
        }

        /// <summary>
        /// Creates one or more upload URLs which can be used by the client to upload raw file data. Content
        /// URls and uploaded content will be garbage collected after 24 hours if not attached to a draft or published
        /// item. Detailed pricing info around uploading content can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/pricing/meters/catalog-meters
        /// </summary>
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
        public async Task<PFResult<PFCatalogCreateUploadUrlsResponse>> CatalogCreateUploadUrlsAsync(
            PFCatalogCreateUploadUrlsRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogCreateUploadUrlsAsync(InteropHandle, request);
        }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_SERVER
        /// <summary>
        /// Deletes all reviews, helpfulness votes, and ratings submitted by the entity specified.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_PROFILE_DOES_NOT_EXIST or any of the global PlayFab Service errors.
        /// See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public async Task<PFResult> CatalogDeleteEntityItemReviewsAsync(
            PFCatalogDeleteEntityItemReviewsRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogDeleteEntityItemReviewsAsync(InteropHandle, request);
        }
#endif

        /// <summary>
        /// Removes an item from working catalog and all published versions from the public catalog.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_DATABASE_THROUGHPUT_EXCEEDED, E_PF_ITEM_NOT_FOUND or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public async Task<PFResult> CatalogDeleteItemAsync(
            PFCatalogDeleteItemRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogDeleteItemAsync(InteropHandle, request);
        }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_SERVER
        /// <summary>
        /// Gets the configuration for the catalog. Only Title Entities can call this API. There is a limit of
        /// 100 requests in 10 seconds for this API. More information about the Catalog Config can be found here:
        /// https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/settings
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetCatalogConfigResponse.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetCatalogConfigGetResultSize"/>
        /// and <see cref="PFCatalogGetCatalogConfigGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCatalogGetCatalogConfigResponse>> CatalogGetCatalogConfigAsync(
            PFCatalogGetCatalogConfigRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogGetCatalogConfigAsync(InteropHandle, request);
        }
#endif

        /// <summary>
        /// Retrieves an item from the working catalog. This item represents the current working state of the
        /// item. GetDraftItem does not work off a cache of the Catalog and should be used when trying to get
        /// recent item updates. However, please note that item references data is cached and may take a few moments
        /// for changes to propagate. Note: SAS tokens provided are valid for 1 hour.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetDraftItemResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetDraftItemGetResultSize"/> and
        /// <see cref="PFCatalogGetDraftItemGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCatalogGetDraftItemResponse>> CatalogGetDraftItemAsync(
            PFCatalogGetDraftItemRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogGetDraftItemAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves a paginated list of the items from the draft catalog. Up to 50 IDs can be retrieved in
        /// a single request. GetDraftItems does not work off a cache of the Catalog and should be used when trying
        /// to get recent item updates. Note: SAS tokens provided are valid for 1 hour.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetDraftItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetDraftItemsGetResultSize"/> and
        /// <see cref="PFCatalogGetDraftItemsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCatalogGetDraftItemsResponse>> CatalogGetDraftItemsAsync(
            PFCatalogGetDraftItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogGetDraftItemsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves a paginated list of the items from the draft catalog created by the Entity. Up to 50 items
        /// can be returned at once. You can use continuation tokens to paginate through results that return greater
        /// than the limit. GetEntityDraftItems does not work off a cache of the Catalog and should be used when
        /// trying to get recent item updates.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetEntityDraftItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetEntityDraftItemsGetResultSize"/>
        /// and <see cref="PFCatalogGetEntityDraftItemsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCatalogGetEntityDraftItemsResponse>> CatalogGetEntityDraftItemsAsync(
            PFCatalogGetEntityDraftItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogGetEntityDraftItemsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Gets the submitted review for the specified item by the authenticated entity. Individual ratings
        /// and reviews data update in near real time with delays within a few seconds.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetEntityItemReviewResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetEntityItemReviewGetResultSize"/>
        /// and <see cref="PFCatalogGetEntityItemReviewGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCatalogGetEntityItemReviewResponse>> CatalogGetEntityItemReviewAsync(
            PFCatalogGetEntityItemReviewRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogGetEntityItemReviewAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves an item from the public catalog. GetItem does not work off a cache of the Catalog and should
        /// be used when trying to get recent item updates. However, please note that item references data is
        /// cached and may take a few moments for changes to propagate.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetItemResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetItemGetResultSize"/> and <see
        /// cref="PFCatalogGetItemGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCatalogGetItemResponse>> CatalogGetItemAsync(
            PFCatalogGetItemRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogGetItemAsync(InteropHandle, request);
        }

        /// <summary>
        /// Search for a given item and return a set of bundles and stores containing the item. Up to 50 items
        /// can be returned at once. You can use continuation tokens to paginate through results that return greater
        /// than the limit. This API is intended for tooling/automation scenarios and has a reduced RPS with Player
        /// Entities limited to 30 requests in 300 seconds and Title Entities limited to 100 requests in 10 seconds.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetItemContainersResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Given an item, return a set of bundles and stores containing the item.
        ///
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetItemContainersGetResultSize"/>
        /// and <see cref="PFCatalogGetItemContainersGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCatalogGetItemContainersResponse>> CatalogGetItemContainersAsync(
            PFCatalogGetItemContainersRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogGetItemContainersAsync(InteropHandle, request);
        }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_SERVER
        /// <summary>
        /// Gets the moderation state for an item, including the concern category and string reason. More information
        /// about moderation states can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/ugc/moderation
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetItemModerationStateResponse.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetItemModerationStateGetResultSize"/>
        /// and <see cref="PFCatalogGetItemModerationStateGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCatalogGetItemModerationStateResponse>> CatalogGetItemModerationStateAsync(
            PFCatalogGetItemModerationStateRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogGetItemModerationStateAsync(InteropHandle, request);
        }
#endif

        /// <summary>
        /// Gets the status of a publish of an item.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetItemPublishStatusResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetItemPublishStatusGetResultSize"/>
        /// and <see cref="PFCatalogGetItemPublishStatusGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCatalogGetItemPublishStatusResponse>> CatalogGetItemPublishStatusAsync(
            PFCatalogGetItemPublishStatusRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogGetItemPublishStatusAsync(InteropHandle, request);
        }

        /// <summary>
        /// Get a paginated set of reviews associated with the specified item. Individual ratings and reviews
        /// data update in near real time with delays within a few seconds.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetItemReviewsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetItemReviewsGetResultSize"/> and
        /// <see cref="PFCatalogGetItemReviewsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCatalogGetItemReviewsResponse>> CatalogGetItemReviewsAsync(
            PFCatalogGetItemReviewsRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogGetItemReviewsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Get a summary of all ratings and reviews associated with the specified item. Summary ratings data
        /// is cached with update data coming within 15 minutes.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetItemReviewSummaryResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetItemReviewSummaryGetResultSize"/>
        /// and <see cref="PFCatalogGetItemReviewSummaryGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCatalogGetItemReviewSummaryResponse>> CatalogGetItemReviewSummaryAsync(
            PFCatalogGetItemReviewSummaryRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogGetItemReviewSummaryAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves items from the public catalog. Up to 50 items can be returned at once. GetItems does not
        /// work off a cache of the Catalog and should be used when trying to get recent item updates. However,
        /// please note that item references data is cached and may take a few moments for changes to propagate.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogGetItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogGetItemsGetResultSize"/> and <see
        /// cref="PFCatalogGetItemsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCatalogGetItemsResponse>> CatalogGetItemsAsync(
            PFCatalogGetItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogGetItemsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Initiates a publish of an item from the working catalog to the public catalog. You can use the GetItemPublishStatus
        /// API to track the state of the item publish.
        /// </summary>
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
        public async Task<PFResult> CatalogPublishDraftItemAsync(
            PFCatalogPublishDraftItemRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogPublishDraftItemAsync(InteropHandle, request);
        }

        /// <summary>
        /// Submit a report for an item, indicating in what way the item is inappropriate.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_DATABASE_THROUGHPUT_EXCEEDED, E_PF_ITEM_NOT_FOUND or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public async Task<PFResult> CatalogReportItemAsync(
            PFCatalogReportItemRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogReportItemAsync(InteropHandle, request);
        }

        /// <summary>
        /// Submit a report for a review
        /// </summary>
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
        public async Task<PFResult> CatalogReportItemReviewAsync(
            PFCatalogReportItemReviewRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogReportItemReviewAsync(InteropHandle, request);
        }

        /// <summary>
        /// Creates or updates a review for the specified item. More information around the caching surrounding
        /// item ratings and reviews can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/ratings#ratings-design-and-caching
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_DATABASE_THROUGHPUT_EXCEEDED, E_PF_ITEM_NOT_FOUND or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public async Task<PFResult> CatalogReviewItemAsync(
            PFCatalogReviewItemRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogReviewItemAsync(InteropHandle, request);
        }

        /// <summary>
        /// Executes a search against the public catalog using the provided search parameters and returns a set
        /// of paginated results. SearchItems uses a cache of the catalog with item updates taking up to a few
        /// minutes to propagate. You should use the GetItem API for when trying to immediately get recent item
        /// updates. More information about the Search API can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/catalog/search
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogSearchItemsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogSearchItemsGetResultSize"/> and
        /// <see cref="PFCatalogSearchItemsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCatalogSearchItemsResponse>> CatalogSearchItemsAsync(
            PFCatalogSearchItemsRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogSearchItemsAsync(InteropHandle, request);
        }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_SERVER
        /// <summary>
        /// Sets the moderation state for an item, including the concern category and string reason. More information
        /// about moderation states can be found here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/ugc/moderation
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_DATABASE_THROUGHPUT_EXCEEDED, E_PF_ITEM_NOT_FOUND or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public async Task<PFResult> CatalogSetItemModerationStateAsync(
            PFCatalogSetItemModerationStateRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogSetItemModerationStateAsync(InteropHandle, request);
        }
#endif

        /// <summary>
        /// Submit a vote for a review, indicating whether the review was helpful or unhelpful.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_DATABASE_THROUGHPUT_EXCEEDED or any of the global PlayFab Service errors.
        /// See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public async Task<PFResult> CatalogSubmitItemReviewVoteAsync(
            PFCatalogSubmitItemReviewVoteRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogSubmitItemReviewVoteAsync(InteropHandle, request);
        }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_SERVER
        /// <summary>
        /// Submit a request to takedown one or more reviews.
        /// </summary>
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
        public async Task<PFResult> CatalogTakedownItemReviewsAsync(
            PFCatalogTakedownItemReviewsRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogTakedownItemReviewsAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_SERVER
        /// <summary>
        /// Updates the configuration for the catalog. Only Title Entities can call this API. There is a limit
        /// of 10 requests in 10 seconds for this API. More information about the Catalog Config can be found
        /// here: https://learn.microsoft.com/en-us/gaming/playfab/features/economy-v2/settings
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_BILLING_INFORMATION_REQUIRED, E_PF_CATALOG_CONFIG_INVALID, E_PF_INVALID_ENTITY_TYPE
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public async Task<PFResult> CatalogUpdateCatalogConfigAsync(
            PFCatalogUpdateCatalogConfigRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogUpdateCatalogConfigAsync(InteropHandle, request);
        }
#endif

        /// <summary>
        /// Update the metadata for an item in the working catalog. Note: SAS tokens provided are valid for 1
        /// hour.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFCatalogUpdateDraftItemResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFCatalogUpdateDraftItemGetResultSize"/>
        /// and <see cref="PFCatalogUpdateDraftItemGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFCatalogUpdateDraftItemResponse>> CatalogUpdateDraftItemAsync(
            PFCatalogUpdateDraftItemRequest request
        )
        {
            return await InteropWrapper.Services.PFCatalog.PFCatalogUpdateDraftItemAsync(InteropHandle, request);
        }
    }
}
