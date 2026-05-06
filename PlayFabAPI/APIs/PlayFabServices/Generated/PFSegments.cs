// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFPlayerEntity
    {
        /// <summary>
        /// List all segments that a player currently belongs to at this moment in time.
        /// </summary>
        /// <returns>A task which will provide the result code for this API operation and a PFSegmentsGetPlayerSegmentsResult.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFSegmentsClientGetPlayerSegmentsGetResultSize"/>
        /// and <see cref="PFSegmentsClientGetPlayerSegmentsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFSegmentsGetPlayerSegmentsResult>> SegmentsClientGetPlayerSegmentsAsync(
            
        )
        {
            return InteropWrapper.Services.PFSegments.PFSegmentsClientGetPlayerSegmentsAsync(InteropHandle);
        }

        /// <summary>
        /// Get all tags with a given Namespace (optional) from a player profile.
        /// </summary>
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
        public Task<PFResult<PFSegmentsGetPlayerTagsResult>> SegmentsClientGetPlayerTagsAsync(
            PFSegmentsGetPlayerTagsRequest request
        )
        {
            return InteropWrapper.Services.PFSegments.PFSegmentsClientGetPlayerTagsAsync(InteropHandle, request);
        }
    }

    public partial class PFTitleEntity
    {
        /// <summary>
        /// Adds a given tag to a player profile. The tag's namespace is automatically generated based on the
        /// source of the tag.
        /// </summary>
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
        public Task<PFResult> SegmentsServerAddPlayerTagAsync(
            PFSegmentsAddPlayerTagRequest request
        )
        {
            return InteropWrapper.Services.PFSegments.PFSegmentsServerAddPlayerTagAsync(InteropHandle, request);
        }

        /// <summary>
        /// Retrieves an array of player segment definitions. Results from this can be used in subsequent API
        /// calls such as GetPlayersInSegment which requires a Segment ID. While segment names can change the
        /// ID for that segment will not change.
        /// </summary>
        /// <returns>A task which will provide the result code for this API operation and a PFSegmentsGetAllSegmentsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// Request has no paramaters. See also ServerGetPlayersInSegmentAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFSegmentsServerGetAllSegmentsGetResultSize"/>
        /// and <see cref="PFSegmentsServerGetAllSegmentsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFSegmentsGetAllSegmentsResult>> SegmentsServerGetAllSegmentsAsync(
            
        )
        {
            return InteropWrapper.Services.PFSegments.PFSegmentsServerGetAllSegmentsAsync(InteropHandle);
        }

        /// <summary>
        /// List all segments that a player currently belongs to at this moment in time.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFSegmentsGetPlayerSegmentsResult.</returns>
        /// <remarks>
        /// This API is available on Windows, Linux, and macOS.
        /// See also ServerGetAllSegmentsAsync.
        ///
        /// When the asynchronous task is complete, call <see cref="PFSegmentsServerGetPlayerSegmentsGetResultSize"/>
        /// and <see cref="PFSegmentsServerGetPlayerSegmentsGetResult"/> to get the result.
        /// </remarks>
        public Task<PFResult<PFSegmentsGetPlayerSegmentsResult>> SegmentsServerGetPlayerSegmentsAsync(
            PFSegmentsGetPlayersSegmentsRequest request
        )
        {
            return InteropWrapper.Services.PFSegments.PFSegmentsServerGetPlayerSegmentsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Get all tags with a given Namespace (optional) from a player profile.
        /// </summary>
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
        public Task<PFResult<PFSegmentsGetPlayerTagsResult>> SegmentsServerGetPlayerTagsAsync(
            PFSegmentsGetPlayerTagsRequest request
        )
        {
            return InteropWrapper.Services.PFSegments.PFSegmentsServerGetPlayerTagsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Remove a given tag from a player profile. The tag's namespace is automatically generated based on
        /// the source of the tag.
        /// </summary>
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
        public Task<PFResult> SegmentsServerRemovePlayerTagAsync(
            PFSegmentsRemovePlayerTagRequest request
        )
        {
            return InteropWrapper.Services.PFSegments.PFSegmentsServerRemovePlayerTagAsync(InteropHandle, request);
        }
    }
}
