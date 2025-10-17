// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFStatistics
    {

        /// <summary>
        /// Create a new entity statistic definition.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also StatisticDeleteStatisticDefinitionAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_AGGREGATION_TYPE_NOT_ALLOWED_FOR_MULTI_COLUMN_STATISTIC, E_PF_API_NOT_ENABLED_FOR_TITLE,
        /// E_PF_DUPLICATE_COLUMN_NAME_FOUND, E_PF_DUPLICATE_STATISTIC_NAME, E_PF_EXTERNAL_ENTITY_NOT_ALLOWED_FOR_TIER,
        /// E_PF_INVALID_BASE_TIME_FOR_INTERVAL, E_PF_MAX_QUERYABLE_VERSIONS_VALUE_NOT_ALLOWED_FOR_TIER, E_PF_PLAY_FAB_ERROR_EVENT_NOT_SUPPORTED_FOR_ENTITY_TYPE,
        /// E_PF_STATISTIC_COUNT_LIMIT_EXCEEDED, E_PF_STATISTIC_DEFINITION_HAS_NULL_OR_EMPTY_VERSION_CONFIGURATION,
        /// E_PF_STATISTIC_NAME_CONFLICT, E_PF_VERSION_CONFIGURATION_IS_REQUIRED or any of the global PlayFab
        /// Service errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFStatisticsCreateStatisticDefinitionAsync(
            PFEntityHandle entityHandle,
            PFStatisticsCreateStatisticDefinitionRequest request
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
                Interop.PFStatisticsCreateStatisticDefinitionRequest* requestInterop = stackalloc Interop.PFStatisticsCreateStatisticDefinitionRequest[1];
                PFStatisticsCreateStatisticDefinitionRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFStatisticsCreateStatisticDefinitionAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Delete an entity statistic definition. Will delete all statistics on entity profiles and leaderboards.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFStatisticsDeleteStatisticDefinitionAsync(
            PFEntityHandle entityHandle,
            PFStatisticsDeleteStatisticDefinitionRequest request
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
                Interop.PFStatisticsDeleteStatisticDefinitionRequest* requestInterop = stackalloc Interop.PFStatisticsDeleteStatisticDefinitionRequest[1];
                PFStatisticsDeleteStatisticDefinitionRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFStatisticsDeleteStatisticDefinitionAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Delete statistics on an entity profile. This will remove all rankings from associated leaderboards.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFStatisticsDeleteStatisticsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also StatisticUpdateStatisticsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFStatisticsDeleteStatisticsGetResultSize"/>
        /// and <see cref="PFStatisticsDeleteStatisticsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFStatisticsDeleteStatisticsResponse>> PFStatisticsDeleteStatisticsAsync(
            PFEntityHandle entityHandle,
            PFStatisticsDeleteStatisticsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFStatisticsDeleteStatisticsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFStatisticsDeleteStatisticsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFStatisticsDeleteStatisticsResponse* result = null;

                    hr = Interop.Methods.PFStatisticsDeleteStatisticsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFStatisticsDeleteStatisticsRequest* requestInterop = stackalloc Interop.PFStatisticsDeleteStatisticsRequest[1];
                PFStatisticsDeleteStatisticsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFStatisticsDeleteStatisticsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Get current statistic definition information
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFStatisticsGetStatisticDefinitionResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also StatisticCreateStatisticDefinitionAsync, StatisticDeleteStatisticDefinitionAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFStatisticsGetStatisticDefinitionGetResultSize"/>
        /// and <see cref="PFStatisticsGetStatisticDefinitionGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFStatisticsGetStatisticDefinitionResponse>> PFStatisticsGetStatisticDefinitionAsync(
            PFEntityHandle entityHandle,
            PFStatisticsGetStatisticDefinitionRequest request
        )
        {
            TaskCompletionSource<PFResult<PFStatisticsGetStatisticDefinitionResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFStatisticsGetStatisticDefinitionGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFStatisticsGetStatisticDefinitionResponse* result = null;

                    hr = Interop.Methods.PFStatisticsGetStatisticDefinitionGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFStatisticsGetStatisticDefinitionRequest* requestInterop = stackalloc Interop.PFStatisticsGetStatisticDefinitionRequest[1];
                PFStatisticsGetStatisticDefinitionRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFStatisticsGetStatisticDefinitionAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Gets statistics for the specified entity.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFStatisticsGetStatisticsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also StatisticDeleteStatisticsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFStatisticsGetStatisticsGetResultSize"/>
        /// and <see cref="PFStatisticsGetStatisticsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFStatisticsGetStatisticsResponse>> PFStatisticsGetStatisticsAsync(
            PFEntityHandle entityHandle,
            PFStatisticsGetStatisticsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFStatisticsGetStatisticsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFStatisticsGetStatisticsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFStatisticsGetStatisticsResponse* result = null;

                    hr = Interop.Methods.PFStatisticsGetStatisticsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFStatisticsGetStatisticsRequest* requestInterop = stackalloc Interop.PFStatisticsGetStatisticsRequest[1];
                PFStatisticsGetStatisticsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFStatisticsGetStatisticsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Gets statistics for the specified collection of entities.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFStatisticsGetStatisticsForEntitiesResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also StatisticDeleteStatisticsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFStatisticsGetStatisticsForEntitiesGetResultSize"/>
        /// and <see cref="PFStatisticsGetStatisticsForEntitiesGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFStatisticsGetStatisticsForEntitiesResponse>> PFStatisticsGetStatisticsForEntitiesAsync(
            PFEntityHandle entityHandle,
            PFStatisticsGetStatisticsForEntitiesRequest request
        )
        {
            TaskCompletionSource<PFResult<PFStatisticsGetStatisticsForEntitiesResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFStatisticsGetStatisticsForEntitiesGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFStatisticsGetStatisticsForEntitiesResponse* result = null;

                    hr = Interop.Methods.PFStatisticsGetStatisticsForEntitiesGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFStatisticsGetStatisticsForEntitiesRequest* requestInterop = stackalloc Interop.PFStatisticsGetStatisticsForEntitiesRequest[1];
                PFStatisticsGetStatisticsForEntitiesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFStatisticsGetStatisticsForEntitiesAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Increment an entity statistic definition version.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFStatisticsIncrementStatisticVersionResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also StatisticCreateStatisticDefinitionAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFStatisticsIncrementStatisticVersionGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<PFStatisticsIncrementStatisticVersionResponse>> PFStatisticsIncrementStatisticVersionAsync(
            PFEntityHandle entityHandle,
            PFStatisticsIncrementStatisticVersionRequest request
        )
        {
            TaskCompletionSource<PFResult<PFStatisticsIncrementStatisticVersionResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    Interop.PFStatisticsIncrementStatisticVersionResponse result = default;

                    hr = Interop.Methods.PFStatisticsIncrementStatisticVersionGetResult(asyncBlock, &result);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFStatisticsIncrementStatisticVersionRequest* requestInterop = stackalloc Interop.PFStatisticsIncrementStatisticVersionRequest[1];
                PFStatisticsIncrementStatisticVersionRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFStatisticsIncrementStatisticVersionAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Get all current statistic definitions information
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFStatisticsListStatisticDefinitionsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also StatisticCreateStatisticDefinitionAsync, StatisticDeleteStatisticDefinitionAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFStatisticsListStatisticDefinitionsGetResultSize"/>
        /// and <see cref="PFStatisticsListStatisticDefinitionsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFStatisticsListStatisticDefinitionsResponse>> PFStatisticsListStatisticDefinitionsAsync(
            PFEntityHandle entityHandle,
            PFStatisticsListStatisticDefinitionsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFStatisticsListStatisticDefinitionsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFStatisticsListStatisticDefinitionsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFStatisticsListStatisticDefinitionsResponse* result = null;

                    hr = Interop.Methods.PFStatisticsListStatisticDefinitionsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFStatisticsListStatisticDefinitionsRequest* requestInterop = stackalloc Interop.PFStatisticsListStatisticDefinitionsRequest[1];
                PFStatisticsListStatisticDefinitionsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFStatisticsListStatisticDefinitionsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Update an existing entity statistic definition.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows.
        /// See also StatisticCreateStatisticDefinitionAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_API_NOT_ENABLED_FOR_TITLE, E_PF_INVALID_BASE_TIME_FOR_INTERVAL, E_PF_MAX_QUERYABLE_VERSIONS_VALUE_NOT_ALLOWED_FOR_TIER,
        /// E_PF_RESET_INTERVAL_CANNOT_BE_MODIFIED, E_PF_STATISTIC_NOT_FOUND or any of the global PlayFab Service
        /// errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFStatisticsUpdateStatisticDefinitionAsync(
            PFEntityHandle entityHandle,
            PFStatisticsUpdateStatisticDefinitionRequest request
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
                Interop.PFStatisticsUpdateStatisticDefinitionRequest* requestInterop = stackalloc Interop.PFStatisticsUpdateStatisticDefinitionRequest[1];
                PFStatisticsUpdateStatisticDefinitionRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFStatisticsUpdateStatisticDefinitionAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Update statistics on an entity profile. Depending on the statistic definition, this may result in
        /// entity being ranked on various leaderboards.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFStatisticsUpdateStatisticsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// See also StatisticDeleteStatisticsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFStatisticsUpdateStatisticsGetResultSize"/>
        /// and <see cref="PFStatisticsUpdateStatisticsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFStatisticsUpdateStatisticsResponse>> PFStatisticsUpdateStatisticsAsync(
            PFEntityHandle entityHandle,
            PFStatisticsUpdateStatisticsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFStatisticsUpdateStatisticsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFStatisticsUpdateStatisticsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFStatisticsUpdateStatisticsResponse* result = null;

                    hr = Interop.Methods.PFStatisticsUpdateStatisticsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFStatisticsUpdateStatisticsRequest* requestInterop = stackalloc Interop.PFStatisticsUpdateStatisticsRequest[1];
                PFStatisticsUpdateStatisticsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFStatisticsUpdateStatisticsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
