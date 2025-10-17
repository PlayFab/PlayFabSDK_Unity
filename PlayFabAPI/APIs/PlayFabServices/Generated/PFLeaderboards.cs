// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFEntity
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Creates a new leaderboard definition.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also LeaderboardDeleteLeaderboardDefinitionAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_API_NOT_ENABLED_FOR_TITLE, E_PF_DUPLICATE_COLUMN_NAME_FOUND, E_PF_DUPLICATE_LINKED_STATISTIC_COLUMN_NAME_FOUND,
        /// E_PF_ENTITY_TYPE_MISMATCH_WITH_STAT_DEFINITION, E_PF_EXTERNAL_ENTITY_NOT_ALLOWED_FOR_TIER, E_PF_INVALID_BASE_TIME_FOR_INTERVAL,
        /// E_PF_LEADERBOARD_COUNT_LIMIT_EXCEEDED, E_PF_LEADERBOARD_NAME_CONFLICT, E_PF_LEADERBOARD_SIZE_LIMIT_EXCEEDED,
        /// E_PF_LINKED_STATISTIC_COLUMN_MISMATCH, E_PF_LINKED_STATISTIC_COLUMN_NOT_FOUND, E_PF_LINKED_STATISTIC_COLUMN_REQUIRED,
        /// E_PF_LINKING_STATS_NOT_ALLOWED_FOR_ENTITY_TYPE, E_PF_MAX_QUERYABLE_VERSIONS_VALUE_NOT_ALLOWED_FOR_TIER,
        /// E_PF_MULTIPLE_LINKED_STATISTICS_NOT_ALLOWED, E_PF_PLAY_FAB_ERROR_EVENT_NOT_SUPPORTED_FOR_ENTITY_TYPE,
        /// E_PF_STAT_DEFINITION_ALREADY_LINKED_TO_LEADERBOARD, E_PF_STATISTIC_NOT_FOUND or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public async Task<PFResult> LeaderboardsCreateLeaderboardDefinitionAsync(
            PFLeaderboardsCreateLeaderboardDefinitionRequest request
        )
        {
            return await InteropWrapper.Services.PFLeaderboards.PFLeaderboardsCreateLeaderboardDefinitionAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Deletes a leaderboard definition.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also LeaderboardCreateLeaderboardDefinitionAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_LEADERBOARD_DEFINITION_MODIFICATION_NOT_ALLOWED_WHILE_LINKED, E_PF_LEADERBOARD_NOT_FOUND
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public async Task<PFResult> LeaderboardsDeleteLeaderboardDefinitionAsync(
            PFLeaderboardsDeleteLeaderboardDefinitionRequest request
        )
        {
            return await InteropWrapper.Services.PFLeaderboards.PFLeaderboardsDeleteLeaderboardDefinitionAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Deletes the specified entries from the given leaderboard.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also LeaderboardUpdateLeaderboardEntriesAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_API_NOT_ENABLED_FOR_TITLE, E_PF_LEADERBOARD_NOT_FOUND, E_PF_LEADERBOARD_UPDATE_NOT_ALLOWED_WHILE_LINKED
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public async Task<PFResult> LeaderboardsDeleteLeaderboardEntriesAsync(
            PFLeaderboardsDeleteLeaderboardEntriesRequest request
        )
        {
            return await InteropWrapper.Services.PFLeaderboards.PFLeaderboardsDeleteLeaderboardEntriesAsync(InteropHandle, request);
        }
#endif

        /// <summary>
        /// Get the friend leaderboard for the specified entity. A maximum of 25 friend entries are listed in
        /// the leaderboard.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFLeaderboardsGetEntityLeaderboardResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFLeaderboardsGetFriendLeaderboardForEntityGetResultSize"/>
        /// and <see cref="PFLeaderboardsGetFriendLeaderboardForEntityGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFLeaderboardsGetEntityLeaderboardResponse>> LeaderboardsGetFriendLeaderboardForEntityAsync(
            PFLeaderboardsGetFriendLeaderboardForEntityRequest request
        )
        {
            return await InteropWrapper.Services.PFLeaderboards.PFLeaderboardsGetFriendLeaderboardForEntityAsync(InteropHandle, request);
        }

        /// <summary>
        /// Get the leaderboard for a specific entity type and statistic.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFLeaderboardsGetEntityLeaderboardResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFLeaderboardsGetLeaderboardGetResultSize"/>
        /// and <see cref="PFLeaderboardsGetLeaderboardGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFLeaderboardsGetEntityLeaderboardResponse>> LeaderboardsGetLeaderboardAsync(
            PFLeaderboardsGetEntityLeaderboardRequest request
        )
        {
            return await InteropWrapper.Services.PFLeaderboards.PFLeaderboardsGetLeaderboardAsync(InteropHandle, request);
        }

        /// <summary>
        /// Get the leaderboard around a specific entity.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFLeaderboardsGetEntityLeaderboardResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFLeaderboardsGetLeaderboardAroundEntityGetResultSize"/>
        /// and <see cref="PFLeaderboardsGetLeaderboardAroundEntityGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFLeaderboardsGetEntityLeaderboardResponse>> LeaderboardsGetLeaderboardAroundEntityAsync(
            PFLeaderboardsGetLeaderboardAroundEntityRequest request
        )
        {
            return await InteropWrapper.Services.PFLeaderboards.PFLeaderboardsGetLeaderboardAroundEntityAsync(InteropHandle, request);
        }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Gets the specified leaderboard definition.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFLeaderboardsGetLeaderboardDefinitionResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also LeaderboardDeleteLeaderboardDefinitionAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFLeaderboardsGetLeaderboardDefinitionGetResultSize"/>
        /// and <see cref="PFLeaderboardsGetLeaderboardDefinitionGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFLeaderboardsGetLeaderboardDefinitionResponse>> LeaderboardsGetLeaderboardDefinitionAsync(
            PFLeaderboardsGetLeaderboardDefinitionRequest request
        )
        {
            return await InteropWrapper.Services.PFLeaderboards.PFLeaderboardsGetLeaderboardDefinitionAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Get the leaderboard limited to a set of entities.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFLeaderboardsGetEntityLeaderboardResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFLeaderboardsGetLeaderboardForEntitiesGetResultSize"/>
        /// and <see cref="PFLeaderboardsGetLeaderboardForEntitiesGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFLeaderboardsGetEntityLeaderboardResponse>> LeaderboardsGetLeaderboardForEntitiesAsync(
            PFLeaderboardsGetLeaderboardForEntitiesRequest request
        )
        {
            return await InteropWrapper.Services.PFLeaderboards.PFLeaderboardsGetLeaderboardForEntitiesAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Increment a leaderboard version.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFLeaderboardsIncrementLeaderboardVersionResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also LeaderboardCreateLeaderboardDefinitionAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFLeaderboardsIncrementLeaderboardVersionGetResult"/>
        /// to get the result.
        /// </remarks>
        public async Task<PFResult<PFLeaderboardsIncrementLeaderboardVersionResponse>> LeaderboardsIncrementLeaderboardVersionAsync(
            PFLeaderboardsIncrementLeaderboardVersionRequest request
        )
        {
            return await InteropWrapper.Services.PFLeaderboards.PFLeaderboardsIncrementLeaderboardVersionAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Lists the leaderboard definitions defined for the Title.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFLeaderboardsListLeaderboardDefinitionsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also LeaderboardDeleteLeaderboardDefinitionAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFLeaderboardsListLeaderboardDefinitionsGetResultSize"/>
        /// and <see cref="PFLeaderboardsListLeaderboardDefinitionsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFLeaderboardsListLeaderboardDefinitionsResponse>> LeaderboardsListLeaderboardDefinitionsAsync(
            PFLeaderboardsListLeaderboardDefinitionsRequest request
        )
        {
            return await InteropWrapper.Services.PFLeaderboards.PFLeaderboardsListLeaderboardDefinitionsAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Unlinks a leaderboard definition from it's linked statistic definition.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also LeaderboardCreateLeaderboardDefinitionAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_LEADERBOARD_NOT_FOUND, E_PF_NO_LINKED_STATISTIC_TO_LEADERBOARD or any
        /// of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error
        /// handling.
        /// </remarks>
        public async Task<PFResult> LeaderboardsUnlinkLeaderboardFromStatisticAsync(
            PFLeaderboardsUnlinkLeaderboardFromStatisticRequest request
        )
        {
            return await InteropWrapper.Services.PFLeaderboards.PFLeaderboardsUnlinkLeaderboardFromStatisticAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_SERVER
        /// <summary>
        /// Updates a leaderboard definition.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// See also LeaderboardDeleteLeaderboardDefinitionAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_LEADERBOARD_SIZE_LIMIT_EXCEEDED, E_PF_MAX_QUERYABLE_VERSIONS_VALUE_NOT_ALLOWED_FOR_TIER,
        /// E_PF_RESET_INTERVAL_CANNOT_BE_MODIFIED or any of the global PlayFab Service errors. See doc page "Handling
        /// PlayFab Errors" for more details on error handling.
        /// </remarks>
        public async Task<PFResult> LeaderboardsUpdateLeaderboardDefinitionAsync(
            PFLeaderboardsUpdateLeaderboardDefinitionRequest request
        )
        {
            return await InteropWrapper.Services.PFLeaderboards.PFLeaderboardsUpdateLeaderboardDefinitionAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Adds or updates entries on the specified leaderboard.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also LeaderboardDeleteLeaderboardEntriesAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_API_NOT_ENABLED_FOR_GAME_CLIENT_ACCESS, E_PF_LEADERBOARD_COLUMN_LENGTH_MISMATCH,
        /// E_PF_LEADERBOARD_NOT_FOUND, E_PF_LEADERBOARD_UPDATE_NOT_ALLOWED_WHILE_LINKED or any of the global
        /// PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public async Task<PFResult> LeaderboardsUpdateLeaderboardEntriesAsync(
            PFLeaderboardsUpdateLeaderboardEntriesRequest request
        )
        {
            return await InteropWrapper.Services.PFLeaderboards.PFLeaderboardsUpdateLeaderboardEntriesAsync(InteropHandle, request);
        }
#endif
    }
}
