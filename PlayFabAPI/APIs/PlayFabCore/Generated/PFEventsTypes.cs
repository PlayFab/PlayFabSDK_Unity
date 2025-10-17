// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// PFEventsEventContents data model.
    /// </summary>
    public struct PFEventsEventContents
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the event (e.g. build number, external trace
        /// identifiers, etc.). Before an event is written, this collection and the base request custom tags will
        /// be merged, but not overriden. This enables the caller to specify static tags and per event tags.
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Entity associated with the event. If null, the event will apply to the calling entity.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// The namespace in which the event is defined. Allowed namespaces can vary by API.
        /// </summary>
        public string EventNamespace;

        /// <summary>
        /// The name of this event.
        /// </summary>
        public string Name;

        /// <summary>
        /// (Optional) The original unique identifier associated with this event before it was posted to PlayFab.
        /// The value might differ from the EventId value, which is assigned when the event is received by the
        /// server.
        /// </summary>
        public string? OriginalId;

        /// <summary>
        /// (Optional) The time (in UTC) associated with this event when it occurred. If specified, this value
        /// is stored in the OriginalTimestamp property of the PlayStream event.
        /// </summary>
        public long? OriginalTimestamp;

        /// <summary>
        /// (Optional) Arbitrary data associated with the event. Only one of Payload or PayloadJSON is allowed.
        /// </summary>
        public PFJsonObject Payload;

        /// <summary>
        /// (Optional) Arbitrary data associated with the event, represented as a JSON serialized string. Only
        /// one of Payload or PayloadJSON is allowed.
        /// </summary>
        public string? PayloadJSON;

        internal unsafe PFEventsEventContents(Interop.PFEventsEventContents interop)
        {

            CustomTags = (interop.customTags == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.customTags, interop.customTagsCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), InteropWrapper.WrapperHelpers.InteropToString(pair.value)));

            Entity = (interop.entity == null) ? null : new(*interop.entity);

            EventNamespace = InteropWrapper.WrapperHelpers.InteropToString(interop.eventNamespace)!;

            Name = InteropWrapper.WrapperHelpers.InteropToString(interop.name)!;

            OriginalId = (interop.originalId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.originalId);

            OriginalTimestamp = (interop.originalTimestamp == null) ? null : *interop.originalTimestamp;

            Payload = (interop.payload.stringValue == null) ? default : new PFJsonObject(interop.payload);

            PayloadJSON = (interop.payloadJSON == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.payloadJSON);

        }

        internal unsafe static void ToInterop(PFEventsEventContents self, Interop.PFEventsEventContents* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.EventNamespace, &interop->eventNamespace, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

            if (self.OriginalId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.OriginalId, &interop->originalId, buffer);
            }

            if (self.OriginalTimestamp != null)
            {
                *interop->originalTimestamp = self.OriginalTimestamp.Value;
            }

            if (self.Payload.stringValue != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Payload.stringValue, &interop->payload.stringValue, buffer);
            }

            if (self.PayloadJSON != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PayloadJSON, &interop->payloadJSON, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFEventsWriteEventsRequest data model.
    /// </summary>
    public struct PFEventsWriteEventsRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The collection of events to write. Up to 200 events can be written per request.
        /// </summary>
        public PFEventsEventContents[] Events;

        internal unsafe static void ToInterop(PFEventsWriteEventsRequest self, Interop.PFEventsWriteEventsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.ArrayToInterop(self.Events, &interop->events, buffer, PFEventsEventContents.ToInterop);
            interop->eventsCount = (uint)self.Events.Length;

        }
            
    }

    /// <summary>
    /// PFEventsWriteEventsResponse data model.
    /// </summary>
    public struct PFEventsWriteEventsResponse
    {
        /// <summary>
        /// (Optional) The unique identifiers assigned by the server to the events, in the same order as the
        /// events in the request. Only returned if FlushToPlayStream option is true.
        /// </summary>
        public string[]? AssignedEventIds;

        internal unsafe PFEventsWriteEventsResponse(Interop.PFEventsWriteEventsResponse interop)
        {

            AssignedEventIds = (interop.assignedEventIds == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.assignedEventIds, interop.assignedEventIdsCount);

        }
            
    }

}
