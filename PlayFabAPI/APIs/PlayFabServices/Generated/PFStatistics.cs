// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFEntity
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Create a new entity statistic definition.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also StatisticDeleteStatisticDefinitionAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_AGGREGATION_TYPE_NOT_ALLOWED_FOR_LINKED_STAT, E_PF_AGGREGATION_TYPE_NOT_ALLOWED_FOR_MULTI_COLUMN_STATISTIC,
        /// E_PF_API_NOT_ENABLED_FOR_TITLE, E_PF_DUPLICATE_COLUMN_NAME_FOUND, E_PF_DUPLICATE_STATISTIC_NAME, E_PF_ENTITY_TYPE_SPECIFIED_REQUIRES_AGGREGATION_SOURCE,
        /// E_PF_EXTERNAL_ENTITY_NOT_ALLOWED_FOR_TIER, E_PF_INVALID_BASE_TIME_FOR_INTERVAL, E_PF_INVALID_ENTITY_TYPE_FOR_AGGREGATION,
        /// E_PF_MAX_QUERYABLE_VERSIONS_EXCEEDED, E_PF_MAX_QUERYABLE_VERSIONS_VALUE_NOT_ALLOWED_FOR_TIER, E_PF_MULTI_LEVEL_AGGREGATION_NOT_ALLOWED,
        /// E_PF_PLAY_FAB_ERROR_EVENT_NOT_SUPPORTED_FOR_ENTITY_TYPE, E_PF_STATISTIC_COLUMN_AGGREGATION_MISMATCH,
        /// E_PF_STATISTIC_COLUMN_LENGTH_MISMATCH, E_PF_STATISTIC_COUNT_LIMIT_EXCEEDED, E_PF_STATISTIC_DEFINITION_HAS_NULL_OR_EMPTY_VERSION_CONFIGURATION,
        /// E_PF_STATISTIC_NAME_CONFLICT, E_PF_STATISTIC_NOT_FOUND, E_PF_VERSION_CONFIGURATION_CANNOT_BE_SPECIFIED_FOR_LINKED_STAT,
        /// E_PF_VERSION_CONFIGURATION_IS_REQUIRED or any of the global PlayFab Service errors. See doc page "Handling
        /// PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> StatisticsCreateStatisticDefinitionAsync(
            PFStatisticsCreateStatisticDefinitionRequest request
        )
        {
            return InteropWrapper.Services.PFStatistics.PFStatisticsCreateStatisticDefinitionAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Delete an entity statistic definition. Will delete all statistics on entity profiles and leaderboards.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also StatisticCreateStatisticDefinitionAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_STATISTIC_DEFINITION_MODIFICATION_NOT_ALLOWED_WHILE_LINKED, E_PF_STATISTIC_NOT_FOUND,
        /// E_PF_STATISTIC_UPDATE_IN_PROGRESS or any of the global PlayFab Service errors. See doc page "Handling
        /// PlayFab Errors" for more details on error handling.
        /// </remarks>
        public Task<PFResult> StatisticsDeleteStatisticDefinitionAsync(
            PFStatisticsDeleteStatisticDefinitionRequest request
        )
        {
            return InteropWrapper.Services.PFStatistics.PFStatisticsDeleteStatisticDefinitionAsync(InteropHandle, request);
        }
#endif

        /// <summary>
        /// Delete statistics on an entity profile. This will remove all rankings from associated leaderboards.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFStatisticsDeleteStatisticsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also StatisticUpdateStatisticsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFStatisticsDeleteStatisticsGetResultSize"/>
        /// and <see cref="PFStatisticsDeleteStatisticsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFStatisticsDeleteStatisticsResponse>> StatisticsDeleteStatisticsAsync(
            PFStatisticsDeleteStatisticsRequest request
        )
        {
            return InteropWrapper.Services.PFStatistics.PFStatisticsDeleteStatisticsAsync(InteropHandle, request);
        }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Get current statistic definition information
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFStatisticsGetStatisticDefinitionResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also StatisticCreateStatisticDefinitionAsync, StatisticDeleteStatisticDefinitionAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFStatisticsGetStatisticDefinitionGetResultSize"/>
        /// and <see cref="PFStatisticsGetStatisticDefinitionGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFStatisticsGetStatisticDefinitionResponse>> StatisticsGetStatisticDefinitionAsync(
            PFStatisticsGetStatisticDefinitionRequest request
        )
        {
            return InteropWrapper.Services.PFStatistics.PFStatisticsGetStatisticDefinitionAsync(InteropHandle, request);
        }
#endif

        /// <summary>
        /// Gets statistics for the specified entity.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFStatisticsGetStatisticsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also StatisticDeleteStatisticsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFStatisticsGetStatisticsGetResultSize"/>
        /// and <see cref="PFStatisticsGetStatisticsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFStatisticsGetStatisticsResponse>> StatisticsGetStatisticsAsync(
            PFStatisticsGetStatisticsRequest request
        )
        {
            return InteropWrapper.Services.PFStatistics.PFStatisticsGetStatisticsAsync(InteropHandle, request);
        }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Gets statistics for the specified collection of entities.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFStatisticsGetStatisticsForEntitiesResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also StatisticDeleteStatisticsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFStatisticsGetStatisticsForEntitiesGetResultSize"/>
        /// and <see cref="PFStatisticsGetStatisticsForEntitiesGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFStatisticsGetStatisticsForEntitiesResponse>> StatisticsGetStatisticsForEntitiesAsync(
            PFStatisticsGetStatisticsForEntitiesRequest request
        )
        {
            return InteropWrapper.Services.PFStatistics.PFStatisticsGetStatisticsForEntitiesAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Increment an entity statistic definition version.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFStatisticsIncrementStatisticVersionResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also StatisticCreateStatisticDefinitionAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFStatisticsIncrementStatisticVersionGetResult"/>
        /// to get the result.
        /// </remarks>
        public Task<PFResult<PFStatisticsIncrementStatisticVersionResponse>> StatisticsIncrementStatisticVersionAsync(
            PFStatisticsIncrementStatisticVersionRequest request
        )
        {
            return InteropWrapper.Services.PFStatistics.PFStatisticsIncrementStatisticVersionAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX || UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX || UNITY_SERVER
        /// <summary>
        /// Get all current statistic definitions information
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFStatisticsListStatisticDefinitionsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also StatisticCreateStatisticDefinitionAsync, StatisticDeleteStatisticDefinitionAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFStatisticsListStatisticDefinitionsGetResultSize"/>
        /// and <see cref="PFStatisticsListStatisticDefinitionsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFStatisticsListStatisticDefinitionsResponse>> StatisticsListStatisticDefinitionsAsync(
            PFStatisticsListStatisticDefinitionsRequest request
        )
        {
            return InteropWrapper.Services.PFStatistics.PFStatisticsListStatisticDefinitionsAsync(InteropHandle, request);
        }
#endif

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || UNITY_SERVER
        /// <summary>
        /// Update an existing entity statistic definition.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// See also StatisticCreateStatisticDefinitionAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_API_NOT_ENABLED_FOR_TITLE, E_PF_INVALID_BASE_TIME_FOR_INTERVAL, E_PF_MAX_QUERYABLE_VERSIONS_EXCEEDED,
        /// E_PF_MAX_QUERYABLE_VERSIONS_VALUE_NOT_ALLOWED_FOR_TIER, E_PF_RESET_INTERVAL_CANNOT_BE_MODIFIED, E_PF_STATISTIC_NOT_FOUND
        /// or any of the global PlayFab Service errors. See doc page "Handling PlayFab Errors" for more details
        /// on error handling.
        /// </remarks>
        public Task<PFResult> StatisticsUpdateStatisticDefinitionAsync(
            PFStatisticsUpdateStatisticDefinitionRequest request
        )
        {
            return InteropWrapper.Services.PFStatistics.PFStatisticsUpdateStatisticDefinitionAsync(InteropHandle, request);
        }
#endif

        /// <summary>
        /// Update statistics on an entity profile. Depending on the statistic definition, this may result in
        /// entity being ranked on various leaderboards.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFStatisticsUpdateStatisticsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also StatisticDeleteStatisticsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFStatisticsUpdateStatisticsGetResultSize"/>
        /// and <see cref="PFStatisticsUpdateStatisticsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFStatisticsUpdateStatisticsResponse>> StatisticsUpdateStatisticsAsync(
            PFStatisticsUpdateStatisticsRequest request
        )
        {
            return InteropWrapper.Services.PFStatistics.PFStatisticsUpdateStatisticsAsync(InteropHandle, request);
        }
    }
}
