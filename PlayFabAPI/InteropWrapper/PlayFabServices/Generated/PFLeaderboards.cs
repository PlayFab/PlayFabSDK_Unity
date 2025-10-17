// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFLeaderboards
    {

        /// <summary>
        /// Creates a new leaderboard definition.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFLeaderboardsCreateLeaderboardDefinitionAsync(
            PFEntityHandle entityHandle,
            PFLeaderboardsCreateLeaderboardDefinitionRequest request
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
                Interop.PFLeaderboardsCreateLeaderboardDefinitionRequest* requestInterop = stackalloc Interop.PFLeaderboardsCreateLeaderboardDefinitionRequest[1];
                PFLeaderboardsCreateLeaderboardDefinitionRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFLeaderboardsCreateLeaderboardDefinitionAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Deletes a leaderboard definition.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFLeaderboardsDeleteLeaderboardDefinitionAsync(
            PFEntityHandle entityHandle,
            PFLeaderboardsDeleteLeaderboardDefinitionRequest request
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
                Interop.PFLeaderboardsDeleteLeaderboardDefinitionRequest* requestInterop = stackalloc Interop.PFLeaderboardsDeleteLeaderboardDefinitionRequest[1];
                PFLeaderboardsDeleteLeaderboardDefinitionRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFLeaderboardsDeleteLeaderboardDefinitionAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Deletes the specified entries from the given leaderboard.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFLeaderboardsDeleteLeaderboardEntriesAsync(
            PFEntityHandle entityHandle,
            PFLeaderboardsDeleteLeaderboardEntriesRequest request
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
                Interop.PFLeaderboardsDeleteLeaderboardEntriesRequest* requestInterop = stackalloc Interop.PFLeaderboardsDeleteLeaderboardEntriesRequest[1];
                PFLeaderboardsDeleteLeaderboardEntriesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFLeaderboardsDeleteLeaderboardEntriesAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Get the friend leaderboard for the specified entity. A maximum of 25 friend entries are listed in
        /// the leaderboard.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFLeaderboardsGetEntityLeaderboardResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFLeaderboardsGetFriendLeaderboardForEntityGetResultSize"/>
        /// and <see cref="PFLeaderboardsGetFriendLeaderboardForEntityGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFLeaderboardsGetEntityLeaderboardResponse>> PFLeaderboardsGetFriendLeaderboardForEntityAsync(
            PFEntityHandle entityHandle,
            PFLeaderboardsGetFriendLeaderboardForEntityRequest request
        )
        {
            TaskCompletionSource<PFResult<PFLeaderboardsGetEntityLeaderboardResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFLeaderboardsGetFriendLeaderboardForEntityGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFLeaderboardsGetEntityLeaderboardResponse* result = null;

                    hr = Interop.Methods.PFLeaderboardsGetFriendLeaderboardForEntityGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFLeaderboardsGetFriendLeaderboardForEntityRequest* requestInterop = stackalloc Interop.PFLeaderboardsGetFriendLeaderboardForEntityRequest[1];
                PFLeaderboardsGetFriendLeaderboardForEntityRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFLeaderboardsGetFriendLeaderboardForEntityAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Get the leaderboard for a specific entity type and statistic.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFLeaderboardsGetEntityLeaderboardResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFLeaderboardsGetLeaderboardGetResultSize"/>
        /// and <see cref="PFLeaderboardsGetLeaderboardGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFLeaderboardsGetEntityLeaderboardResponse>> PFLeaderboardsGetLeaderboardAsync(
            PFEntityHandle entityHandle,
            PFLeaderboardsGetEntityLeaderboardRequest request
        )
        {
            TaskCompletionSource<PFResult<PFLeaderboardsGetEntityLeaderboardResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFLeaderboardsGetLeaderboardGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFLeaderboardsGetEntityLeaderboardResponse* result = null;

                    hr = Interop.Methods.PFLeaderboardsGetLeaderboardGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFLeaderboardsGetEntityLeaderboardRequest* requestInterop = stackalloc Interop.PFLeaderboardsGetEntityLeaderboardRequest[1];
                PFLeaderboardsGetEntityLeaderboardRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFLeaderboardsGetLeaderboardAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Get the leaderboard around a specific entity.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFLeaderboardsGetEntityLeaderboardResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFLeaderboardsGetLeaderboardAroundEntityGetResultSize"/>
        /// and <see cref="PFLeaderboardsGetLeaderboardAroundEntityGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFLeaderboardsGetEntityLeaderboardResponse>> PFLeaderboardsGetLeaderboardAroundEntityAsync(
            PFEntityHandle entityHandle,
            PFLeaderboardsGetLeaderboardAroundEntityRequest request
        )
        {
            TaskCompletionSource<PFResult<PFLeaderboardsGetEntityLeaderboardResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFLeaderboardsGetLeaderboardAroundEntityGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFLeaderboardsGetEntityLeaderboardResponse* result = null;

                    hr = Interop.Methods.PFLeaderboardsGetLeaderboardAroundEntityGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFLeaderboardsGetLeaderboardAroundEntityRequest* requestInterop = stackalloc Interop.PFLeaderboardsGetLeaderboardAroundEntityRequest[1];
                PFLeaderboardsGetLeaderboardAroundEntityRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFLeaderboardsGetLeaderboardAroundEntityAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Gets the specified leaderboard definition.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFLeaderboardsGetLeaderboardDefinitionResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also LeaderboardDeleteLeaderboardDefinitionAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFLeaderboardsGetLeaderboardDefinitionGetResultSize"/>
        /// and <see cref="PFLeaderboardsGetLeaderboardDefinitionGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFLeaderboardsGetLeaderboardDefinitionResponse>> PFLeaderboardsGetLeaderboardDefinitionAsync(
            PFEntityHandle entityHandle,
            PFLeaderboardsGetLeaderboardDefinitionRequest request
        )
        {
            TaskCompletionSource<PFResult<PFLeaderboardsGetLeaderboardDefinitionResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFLeaderboardsGetLeaderboardDefinitionGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFLeaderboardsGetLeaderboardDefinitionResponse* result = null;

                    hr = Interop.Methods.PFLeaderboardsGetLeaderboardDefinitionGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFLeaderboardsGetLeaderboardDefinitionRequest* requestInterop = stackalloc Interop.PFLeaderboardsGetLeaderboardDefinitionRequest[1];
                PFLeaderboardsGetLeaderboardDefinitionRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFLeaderboardsGetLeaderboardDefinitionAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Get the leaderboard limited to a set of entities.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFLeaderboardsGetEntityLeaderboardResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// When the asynchronous task is complete, call <see cref="PFLeaderboardsGetLeaderboardForEntitiesGetResultSize"/>
        /// and <see cref="PFLeaderboardsGetLeaderboardForEntitiesGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFLeaderboardsGetEntityLeaderboardResponse>> PFLeaderboardsGetLeaderboardForEntitiesAsync(
            PFEntityHandle entityHandle,
            PFLeaderboardsGetLeaderboardForEntitiesRequest request
        )
        {
            TaskCompletionSource<PFResult<PFLeaderboardsGetEntityLeaderboardResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFLeaderboardsGetLeaderboardForEntitiesGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFLeaderboardsGetEntityLeaderboardResponse* result = null;

                    hr = Interop.Methods.PFLeaderboardsGetLeaderboardForEntitiesGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFLeaderboardsGetLeaderboardForEntitiesRequest* requestInterop = stackalloc Interop.PFLeaderboardsGetLeaderboardForEntitiesRequest[1];
                PFLeaderboardsGetLeaderboardForEntitiesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFLeaderboardsGetLeaderboardForEntitiesAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Increment a leaderboard version.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFLeaderboardsIncrementLeaderboardVersionResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also LeaderboardCreateLeaderboardDefinitionAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFLeaderboardsIncrementLeaderboardVersionGetResult"/>
        /// to get the result.
        /// </remarks>
        public static Task<PFResult<PFLeaderboardsIncrementLeaderboardVersionResponse>> PFLeaderboardsIncrementLeaderboardVersionAsync(
            PFEntityHandle entityHandle,
            PFLeaderboardsIncrementLeaderboardVersionRequest request
        )
        {
            TaskCompletionSource<PFResult<PFLeaderboardsIncrementLeaderboardVersionResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    Interop.PFLeaderboardsIncrementLeaderboardVersionResponse result = default;

                    hr = Interop.Methods.PFLeaderboardsIncrementLeaderboardVersionGetResult(asyncBlock, &result);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFLeaderboardsIncrementLeaderboardVersionRequest* requestInterop = stackalloc Interop.PFLeaderboardsIncrementLeaderboardVersionRequest[1];
                PFLeaderboardsIncrementLeaderboardVersionRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFLeaderboardsIncrementLeaderboardVersionAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Lists the leaderboard definitions defined for the Title.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFLeaderboardsListLeaderboardDefinitionsResponse.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also LeaderboardDeleteLeaderboardDefinitionAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFLeaderboardsListLeaderboardDefinitionsGetResultSize"/>
        /// and <see cref="PFLeaderboardsListLeaderboardDefinitionsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFLeaderboardsListLeaderboardDefinitionsResponse>> PFLeaderboardsListLeaderboardDefinitionsAsync(
            PFEntityHandle entityHandle,
            PFLeaderboardsListLeaderboardDefinitionsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFLeaderboardsListLeaderboardDefinitionsResponse>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFLeaderboardsListLeaderboardDefinitionsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFLeaderboardsListLeaderboardDefinitionsResponse* result = null;

                    hr = Interop.Methods.PFLeaderboardsListLeaderboardDefinitionsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFLeaderboardsListLeaderboardDefinitionsRequest* requestInterop = stackalloc Interop.PFLeaderboardsListLeaderboardDefinitionsRequest[1];
                PFLeaderboardsListLeaderboardDefinitionsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFLeaderboardsListLeaderboardDefinitionsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Unlinks a leaderboard definition from it's linked statistic definition.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFLeaderboardsUnlinkLeaderboardFromStatisticAsync(
            PFEntityHandle entityHandle,
            PFLeaderboardsUnlinkLeaderboardFromStatisticRequest request
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
                Interop.PFLeaderboardsUnlinkLeaderboardFromStatisticRequest* requestInterop = stackalloc Interop.PFLeaderboardsUnlinkLeaderboardFromStatisticRequest[1];
                PFLeaderboardsUnlinkLeaderboardFromStatisticRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFLeaderboardsUnlinkLeaderboardFromStatisticAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Updates a leaderboard definition.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFLeaderboardsUpdateLeaderboardDefinitionAsync(
            PFEntityHandle entityHandle,
            PFLeaderboardsUpdateLeaderboardDefinitionRequest request
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
                Interop.PFLeaderboardsUpdateLeaderboardDefinitionRequest* requestInterop = stackalloc Interop.PFLeaderboardsUpdateLeaderboardDefinitionRequest[1];
                PFLeaderboardsUpdateLeaderboardDefinitionRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFLeaderboardsUpdateLeaderboardDefinitionAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Adds or updates entries on the specified leaderboard.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
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
        public static Task<PFResult> PFLeaderboardsUpdateLeaderboardEntriesAsync(
            PFEntityHandle entityHandle,
            PFLeaderboardsUpdateLeaderboardEntriesRequest request
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
                Interop.PFLeaderboardsUpdateLeaderboardEntriesRequest* requestInterop = stackalloc Interop.PFLeaderboardsUpdateLeaderboardEntriesRequest[1];
                PFLeaderboardsUpdateLeaderboardEntriesRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFLeaderboardsUpdateLeaderboardEntriesAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
