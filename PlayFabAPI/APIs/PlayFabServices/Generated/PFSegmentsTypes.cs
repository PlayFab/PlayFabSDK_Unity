// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// PFSegmentsGetSegmentResult data model.
    /// </summary>
    public struct PFSegmentsGetSegmentResult
    {
        /// <summary>
        /// (Optional) Identifier of the segments AB Test, if it is attached to one.
        /// </summary>
        public string? ABTestParent;

        /// <summary>
        /// Unique identifier for this segment.
        /// </summary>
        public string Id;

        /// <summary>
        /// (Optional) Segment name.
        /// </summary>
        public string? Name;

        internal unsafe PFSegmentsGetSegmentResult(Interop.PFSegmentsGetSegmentResult interop)
        {

            ABTestParent = (interop.aBTestParent == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.aBTestParent);

            Id = InteropWrapper.WrapperHelpers.InteropToString(interop.id)!;

            Name = (interop.name == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.name);

        }

        internal unsafe static void ToInterop(PFSegmentsGetSegmentResult self, Interop.PFSegmentsGetSegmentResult* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.ABTestParent != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ABTestParent, &interop->aBTestParent, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);

            if (self.Name != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);
            }

        }
    }

    /// <summary>
    /// PFSegmentsGetPlayerSegmentsResult data model.
    /// </summary>
    public struct PFSegmentsGetPlayerSegmentsResult
    {
        /// <summary>
        /// (Optional) Array of segments the requested player currently belongs to.
        /// </summary>
        public PFSegmentsGetSegmentResult[]? Segments;

        internal unsafe PFSegmentsGetPlayerSegmentsResult(Interop.PFSegmentsGetPlayerSegmentsResult interop)
        {

            Segments = (interop.segments == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.segments, interop.segmentsCount, elem => new PFSegmentsGetSegmentResult(elem));

        }
    }

    /// <summary>
    /// PFSegmentsGetPlayerTagsRequest data model. This API will return a list of canonical tags which includes
    /// both namespace and tag's name. If namespace is not provided, the result is a list of all canonical
    /// tags. TagName can be used for segmentation and Namespace is limited to 128 characters.
    /// </summary>
    public struct PFSegmentsGetPlayerTagsRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Optional namespace to filter results by.
        /// </summary>
        public string? playfabNamespace;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFSegmentsGetPlayerTagsRequest self, Interop.PFSegmentsGetPlayerTagsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.playfabNamespace != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.playfabNamespace, &interop->playfabNamespace, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFSegmentsGetPlayerTagsResult data model.
    /// </summary>
    public struct PFSegmentsGetPlayerTagsResult
    {
        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Canonical tags (including namespace and tag's name) for the requested user.
        /// </summary>
        public string[] Tags;

        internal unsafe PFSegmentsGetPlayerTagsResult(Interop.PFSegmentsGetPlayerTagsResult interop)
        {

            PlayFabId = InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId)!;

            Tags = InteropWrapper.WrapperHelpers.InteropToStringArray(interop.tags, interop.tagsCount)!;

        }
    }

    /// <summary>
    /// PFSegmentsAddPlayerTagRequest data model. This API will trigger a player_tag_added event and add
    /// a tag with the given TagName and PlayFabID to the corresponding player profile. TagName can be used
    /// for segmentation and it is limited to 256 characters. Also there is a limit on the number of tags
    /// a title can have.
    /// </summary>
    public struct PFSegmentsAddPlayerTagRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique tag for player profile.
        /// </summary>
        public string TagName;

        internal unsafe static void ToInterop(PFSegmentsAddPlayerTagRequest self, Interop.PFSegmentsAddPlayerTagRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.TagName, &interop->tagName, buffer);

        }
    }

    /// <summary>
    /// PFSegmentsGetAllSegmentsResult data model.
    /// </summary>
    public struct PFSegmentsGetAllSegmentsResult
    {
        /// <summary>
        /// (Optional) Array of segments for this title.
        /// </summary>
        public PFSegmentsGetSegmentResult[]? Segments;

        internal unsafe PFSegmentsGetAllSegmentsResult(Interop.PFSegmentsGetAllSegmentsResult interop)
        {

            Segments = (interop.segments == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.segments, interop.segmentsCount, elem => new PFSegmentsGetSegmentResult(elem));

        }
    }

    /// <summary>
    /// PFSegmentsGetPlayersSegmentsRequest data model.
    /// </summary>
    public struct PFSegmentsGetPlayersSegmentsRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        internal unsafe static void ToInterop(PFSegmentsGetPlayersSegmentsRequest self, Interop.PFSegmentsGetPlayersSegmentsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

        }
    }

    /// <summary>
    /// PFSegmentsRemovePlayerTagRequest data model. This API will trigger a player_tag_removed event and
    /// remove a tag with the given TagName and PlayFabID from the corresponding player profile. TagName can
    /// be used for segmentation and it is limited to 256 characters.
    /// </summary>
    public struct PFSegmentsRemovePlayerTagRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId;

        /// <summary>
        /// Unique tag for player profile.
        /// </summary>
        public string TagName;

        internal unsafe static void ToInterop(PFSegmentsRemovePlayerTagRequest self, Interop.PFSegmentsRemovePlayerTagRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.TagName, &interop->tagName, buffer);

        }
    }

}
