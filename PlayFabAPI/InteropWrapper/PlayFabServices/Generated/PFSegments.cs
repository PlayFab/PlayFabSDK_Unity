// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace PlayFab.InteropWrapper.Services
{
    public static partial class PFSegments
    {

        /// <summary>
        /// List all segments that a player currently belongs to at this moment in time.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFSegmentsGetPlayerSegmentsResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFSegmentsClientGetPlayerSegmentsGetResultSize"/>
        /// and <see cref="PFSegmentsClientGetPlayerSegmentsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFSegmentsGetPlayerSegmentsResult>> PFSegmentsClientGetPlayerSegmentsAsync(
            PFEntityHandle entityHandle
        )
        {
            TaskCompletionSource<PFResult<PFSegmentsGetPlayerSegmentsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFSegmentsClientGetPlayerSegmentsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFSegmentsGetPlayerSegmentsResult* result = null;

                    hr = Interop.Methods.PFSegmentsClientGetPlayerSegmentsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                int hr = Interop.Methods.PFSegmentsClientGetPlayerSegmentsAsync(entityHandle.Handle, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Get all tags with a given Namespace (optional) from a player profile.
        /// </summary>
        /// <param name="entityHandle">PFEntityHandle to use for authentication.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFSegmentsGetPlayerTagsResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// This API will return a list of canonical tags which includes both namespace and tag's name. If namespace
        /// is not provided, the result is a list of all canonical tags. TagName can be used for segmentation
        /// and Namespace is limited to 128 characters.
        ///
        /// When the asynchronous task is complete, call <see cref="PFSegmentsClientGetPlayerTagsGetResultSize"/>
        /// and <see cref="PFSegmentsClientGetPlayerTagsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFSegmentsGetPlayerTagsResult>> PFSegmentsClientGetPlayerTagsAsync(
            PFEntityHandle entityHandle,
            PFSegmentsGetPlayerTagsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFSegmentsGetPlayerTagsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFSegmentsClientGetPlayerTagsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFSegmentsGetPlayerTagsResult* result = null;

                    hr = Interop.Methods.PFSegmentsClientGetPlayerTagsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFSegmentsGetPlayerTagsRequest* requestInterop = stackalloc Interop.PFSegmentsGetPlayerTagsRequest[1];
                PFSegmentsGetPlayerTagsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFSegmentsClientGetPlayerTagsAsync(entityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Adds a given tag to a player profile. The tag's namespace is automatically generated based on the
        /// source of the tag.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This API will trigger a player_tag_added event and add a tag with the given TagName and PlayFabID
        /// to the corresponding player profile. TagName can be used for segmentation and it is limited to 256
        /// characters. Also there is a limit on the number of tags a title can have. See also ServerGetPlayerTagsAsync,
        /// ServerRemovePlayerTagAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be E_PF_PLAYER_TAG_COUNT_LIMIT_EXCEEDED or any of the global PlayFab Service
        /// errors. See doc page "Handling PlayFab Errors" for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFSegmentsServerAddPlayerTagAsync(
            PFEntityHandle titleEntityHandle,
            PFSegmentsAddPlayerTagRequest request
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
                Interop.PFSegmentsAddPlayerTagRequest* requestInterop = stackalloc Interop.PFSegmentsAddPlayerTagRequest[1];
                PFSegmentsAddPlayerTagRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFSegmentsServerAddPlayerTagAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Retrieves an array of player segment definitions. Results from this can be used in subsequent API
        /// calls such as GetPlayersInSegment which requires a Segment ID. While segment names can change the
        /// ID for that segment will not change.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFSegmentsGetAllSegmentsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Request has no paramaters. See also ServerGetPlayersInSegmentAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFSegmentsServerGetAllSegmentsGetResultSize"/>
        /// and <see cref="PFSegmentsServerGetAllSegmentsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFSegmentsGetAllSegmentsResult>> PFSegmentsServerGetAllSegmentsAsync(
            PFEntityHandle titleEntityHandle
        )
        {
            TaskCompletionSource<PFResult<PFSegmentsGetAllSegmentsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFSegmentsServerGetAllSegmentsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFSegmentsGetAllSegmentsResult* result = null;

                    hr = Interop.Methods.PFSegmentsServerGetAllSegmentsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                int hr = Interop.Methods.PFSegmentsServerGetAllSegmentsAsync(titleEntityHandle.Handle, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// List all segments that a player currently belongs to at this moment in time.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFSegmentsGetPlayerSegmentsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerGetAllSegmentsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFSegmentsServerGetPlayerSegmentsGetResultSize"/>
        /// and <see cref="PFSegmentsServerGetPlayerSegmentsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFSegmentsGetPlayerSegmentsResult>> PFSegmentsServerGetPlayerSegmentsAsync(
            PFEntityHandle titleEntityHandle,
            PFSegmentsGetPlayersSegmentsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFSegmentsGetPlayerSegmentsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFSegmentsServerGetPlayerSegmentsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFSegmentsGetPlayerSegmentsResult* result = null;

                    hr = Interop.Methods.PFSegmentsServerGetPlayerSegmentsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFSegmentsGetPlayersSegmentsRequest* requestInterop = stackalloc Interop.PFSegmentsGetPlayersSegmentsRequest[1];
                PFSegmentsGetPlayersSegmentsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFSegmentsServerGetPlayerSegmentsAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Get all tags with a given Namespace (optional) from a player profile.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFSegmentsGetPlayerTagsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This API will return a list of canonical tags which includes both namespace and tag's name. If namespace
        /// is not provided, the result is a list of all canonical tags. TagName can be used for segmentation
        /// and Namespace is limited to 128 characters. See also ServerAddPlayerTagAsync, ServerRemovePlayerTagAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFSegmentsServerGetPlayerTagsGetResultSize"/>
        /// and <see cref="PFSegmentsServerGetPlayerTagsGetResult"/> to get the result.
        /// </remarks>
        public static Task<PFResult<PFSegmentsGetPlayerTagsResult>> PFSegmentsServerGetPlayerTagsAsync(
            PFEntityHandle titleEntityHandle,
            PFSegmentsGetPlayerTagsRequest request
        )
        {
            TaskCompletionSource<PFResult<PFSegmentsGetPlayerTagsResult>> completionSource = new();

            unsafe
            {
                Interop.XAsyncBlockPtr asyncBlock = AsyncHelpers.WrapAsyncBlock(AsyncHelpers.DefaultQueue.handle, (Interop.XAsyncBlockPtr block) =>
                {
                    int hr;
                    Interop.XAsyncBlock* asyncBlock = (Interop.XAsyncBlock*)block.Handle;

                    ulong bufferSize;
                    hr = Interop.Methods.PFSegmentsServerGetPlayerTagsGetResultSize(asyncBlock, &bufferSize);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    using DisposableBuffer disposableBuffer = new();
                    void* buffer = disposableBuffer.AddBuffer((int)bufferSize).ToPointer();
                    Interop.PFSegmentsGetPlayerTagsResult* result = null;

                    hr = Interop.Methods.PFSegmentsServerGetPlayerTagsGetResult(asyncBlock, bufferSize, buffer, &result, null);

                    if (HRESULT.Failed(hr))
                    {
                        completionSource.SetResult(new(hr));
                        return;
                    }

                    completionSource.SetResult(new(new(*result), hr));
                });

                using DisposableBuffer disposableBuffer = new();
                Interop.PFSegmentsGetPlayerTagsRequest* requestInterop = stackalloc Interop.PFSegmentsGetPlayerTagsRequest[1];
                PFSegmentsGetPlayerTagsRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFSegmentsServerGetPlayerTagsAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

                if (HRESULT.Failed(hr))
                {
                    completionSource.SetResult(new(hr));
                    AsyncHelpers.CleanupAsyncBlock(asyncBlock);
                }
            }

            return completionSource.Task;
        }

        /// <summary>
        /// Remove a given tag from a player profile. The tag's namespace is automatically generated based on
        /// the source of the tag.
        /// </summary>
        /// <param name="titleEntityHandle">PFEntityHandle for a title Entity obtained using PFAuthenticationGetEntityWithSecretKeyAsync.</param>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// This API will trigger a player_tag_removed event and remove a tag with the given TagName and PlayFabID
        /// from the corresponding player profile. TagName can be used for segmentation and it is limited to 256
        /// characters See also ServerAddPlayerTagAsync, ServerGetPlayerTagsAsync.
        ///
        /// Call <see cref="XAsyncGetStatus"/> to get the status of the operation. If the service call is unsuccessful,
        /// the async result will be one of global PlayFab Service errors. See doc page "Handling PlayFab Errors"
        /// for more details on error handling.
        /// </remarks>
        public static Task<PFResult> PFSegmentsServerRemovePlayerTagAsync(
            PFEntityHandle titleEntityHandle,
            PFSegmentsRemovePlayerTagRequest request
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
                Interop.PFSegmentsRemovePlayerTagRequest* requestInterop = stackalloc Interop.PFSegmentsRemovePlayerTagRequest[1];
                PFSegmentsRemovePlayerTagRequest.ToInterop(request, requestInterop, disposableBuffer);

                int hr = Interop.Methods.PFSegmentsServerRemovePlayerTagAsync(titleEntityHandle.Handle, requestInterop, (Interop.XAsyncBlock*)asyncBlock.Handle);

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
