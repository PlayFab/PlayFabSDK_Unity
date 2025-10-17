// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// PFTitleDataManagementGetPublisherDataRequest data model. This API is designed to return publisher-specific
    /// values which can be read, but not written to, by the client. This data is shared across all titles
    /// assigned to a particular publisher, and can be used for cross-game coordination. Only titles assigned
    /// to a publisher can use this API. For more information email helloplayfab@microsoft.com. Note that
    /// there may up to a minute delay in between updating title data and this API call returning the newest
    /// value.
    /// </summary>
    public struct PFTitleDataManagementGetPublisherDataRequest
    {
        /// <summary>
        ///  array of keys to get back data from the Publisher data blob, set by the admin tools.
        /// </summary>
        public string[] Keys;

        internal unsafe static void ToInterop(PFTitleDataManagementGetPublisherDataRequest self, Interop.PFTitleDataManagementGetPublisherDataRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Keys, &interop->keys, buffer);
            interop->keysCount = (uint)self.Keys.Length;

        }
            
    }

    /// <summary>
    /// PFTitleDataManagementGetPublisherDataResult data model.
    /// </summary>
    public struct PFTitleDataManagementGetPublisherDataResult
    {
        /// <summary>
        /// (Optional) A dictionary object of key / value pairs.
        /// </summary>
        public Dictionary<string, string>? Data;

        internal unsafe PFTitleDataManagementGetPublisherDataResult(Interop.PFTitleDataManagementGetPublisherDataResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.data, interop.dataCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), InteropWrapper.WrapperHelpers.InteropToString(pair.value)));

        }
            
    }

    /// <summary>
    /// PFTitleDataManagementGetTimeResult data model. Time is always returned as Coordinated Universal Time
    /// (UTC).
    /// </summary>
    public struct PFTitleDataManagementGetTimeResult
    {
        /// <summary>
        /// Current server time when the request was received, in UTC.
        /// </summary>
        public long Time;

        internal unsafe PFTitleDataManagementGetTimeResult(Interop.PFTitleDataManagementGetTimeResult interop)
        {

            Time = interop.time;

        }
            
    }

    /// <summary>
    /// PFTitleDataManagementGetTitleDataRequest data model. This API is designed to return title specific
    /// values which can be read, but not written to, by the client. For example, a developer could choose
    /// to store values which modify the user experience, such as enemy spawn rates, weapon strengths, movement
    /// speeds, etc. This allows a developer to update the title without the need to create, test, and ship
    /// a new build. If the player belongs to an experiment variant that uses title data overrides, the overrides
    /// are applied automatically and returned with the title data. Note that there may up to a minute delay
    /// in between updating title data and this API call returning the newest value.
    /// </summary>
    public struct PFTitleDataManagementGetTitleDataRequest
    {
        /// <summary>
        /// (Optional) Specific keys to search for in the title data (leave null to get all keys).
        /// </summary>
        public string[]? Keys;

        /// <summary>
        /// (Optional) Optional field that specifies the name of an override. This value is ignored when used
        /// by the game client; otherwise, the overrides are applied automatically to the title data.
        /// </summary>
        public string? OverrideLabel;

        internal unsafe static void ToInterop(PFTitleDataManagementGetTitleDataRequest self, Interop.PFTitleDataManagementGetTitleDataRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Keys != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Keys, &interop->keys, buffer);
                interop->keysCount = (uint)self.Keys.Length;
            }

            if (self.OverrideLabel != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.OverrideLabel, &interop->overrideLabel, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFTitleDataManagementGetTitleDataResult data model.
    /// </summary>
    public struct PFTitleDataManagementGetTitleDataResult
    {
        /// <summary>
        /// (Optional) A dictionary object of key / value pairs.
        /// </summary>
        public Dictionary<string, string>? Data;

        internal unsafe PFTitleDataManagementGetTitleDataResult(Interop.PFTitleDataManagementGetTitleDataResult interop)
        {

            Data = (interop.data == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.data, interop.dataCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), InteropWrapper.WrapperHelpers.InteropToString(pair.value)));

        }
            
    }

    /// <summary>
    /// PFTitleDataManagementGetTitleNewsRequest data model.
    /// </summary>
    public struct PFTitleDataManagementGetTitleNewsRequest
    {
        /// <summary>
        /// (Optional) Limits the results to the last n entries. Defaults to 10 if not set.
        /// </summary>
        public int? Count;

        internal unsafe static void ToInterop(PFTitleDataManagementGetTitleNewsRequest self, Interop.PFTitleDataManagementGetTitleNewsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Count != null)
            {
                *interop->count = self.Count.Value;
            }

        }
            
    }

    /// <summary>
    /// PFTitleDataManagementTitleNewsItem data model.
    /// </summary>
    public struct PFTitleDataManagementTitleNewsItem
    {
        /// <summary>
        /// (Optional) News item text.
        /// </summary>
        public string? Body;

        /// <summary>
        /// (Optional) Unique identifier of news item.
        /// </summary>
        public string? NewsId;

        /// <summary>
        /// Date and time when the news item was posted.
        /// </summary>
        public long Timestamp;

        /// <summary>
        /// (Optional) Title of the news item.
        /// </summary>
        public string? Title;

        internal unsafe PFTitleDataManagementTitleNewsItem(Interop.PFTitleDataManagementTitleNewsItem interop)
        {

            Body = (interop.body == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.body);

            NewsId = (interop.newsId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.newsId);

            Timestamp = interop.timestamp;

            Title = (interop.title == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.title);

        }

        internal unsafe static void ToInterop(PFTitleDataManagementTitleNewsItem self, Interop.PFTitleDataManagementTitleNewsItem* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Body != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Body, &interop->body, buffer);
            }

            if (self.NewsId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.NewsId, &interop->newsId, buffer);
            }

            interop->timestamp = self.Timestamp;

            if (self.Title != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Title, &interop->title, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFTitleDataManagementGetTitleNewsResult data model.
    /// </summary>
    public struct PFTitleDataManagementGetTitleNewsResult
    {
        /// <summary>
        /// (Optional) Array of news items.
        /// </summary>
        public PFTitleDataManagementTitleNewsItem[]? News;

        internal unsafe PFTitleDataManagementGetTitleNewsResult(Interop.PFTitleDataManagementGetTitleNewsResult interop)
        {

            News = (interop.news == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.news, interop.newsCount, elem => new PFTitleDataManagementTitleNewsItem(elem));

        }
            
    }

    /// <summary>
    /// PFTitleDataManagementSetPublisherDataRequest data model. This API is designed to store publisher-specific
    /// values which can be read, but not written to, by the client. This data is shared across all titles
    /// assigned to a particular publisher, and can be used for cross-game coordination. Only titles assigned
    /// to a publisher can use this API. This operation is additive. If a Key does not exist in the current
    /// dataset, it will be added with the specified Value. If it already exists, the Value for that key will
    /// be overwritten with the new Value. For more information email helloplayfab@microsoft.com.
    /// </summary>
    public struct PFTitleDataManagementSetPublisherDataRequest
    {
        /// <summary>
        /// Key we want to set a value on (note, this is additive - will only replace an existing key's value
        /// if they are the same name.) Keys are trimmed of whitespace. Keys may not begin with the '!' character.
        /// </summary>
        public string Key;

        /// <summary>
        /// (Optional) New value to set. Set to null to remove a value.
        /// </summary>
        public string? Value;

        internal unsafe static void ToInterop(PFTitleDataManagementSetPublisherDataRequest self, Interop.PFTitleDataManagementSetPublisherDataRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.Key, &interop->key, buffer);

            if (self.Value != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Value, &interop->value, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFTitleDataManagementSetTitleDataRequest data model. This API is designed to store title specific
    /// values which can be read, but not written to, by the client. For example, a developer could choose
    /// to store values which modify the user experience, such as enemy spawn rates, weapon strengths, movement
    /// speeds, etc. This allows a developer to update the title without the need to create, test, and ship
    /// a new build. This operation is additive. If a Key does not exist in the current dataset, it will be
    /// added with the specified Value. If it already exists, the Value for that key will be overwritten with
    /// the new Value.
    /// </summary>
    public struct PFTitleDataManagementSetTitleDataRequest
    {
        /// <summary>
        /// Key we want to set a value on (note, this is additive - will only replace an existing key's value
        /// if they are the same name.) Keys are trimmed of whitespace. Keys may not begin with the '!' character.
        /// </summary>
        public string Key;

        /// <summary>
        /// (Optional) New value to set. Set to null to remove a value.
        /// </summary>
        public string? Value;

        internal unsafe static void ToInterop(PFTitleDataManagementSetTitleDataRequest self, Interop.PFTitleDataManagementSetTitleDataRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.Key, &interop->key, buffer);

            if (self.Value != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Value, &interop->value, buffer);
            }

        }
            
    }

}
