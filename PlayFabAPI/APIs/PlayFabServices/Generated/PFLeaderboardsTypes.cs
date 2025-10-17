// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// LeaderboardSortDirection enum.
    /// </summary>
    public enum PFLeaderboardsLeaderboardSortDirection : uint
    {
        Descending = Interop.PFLeaderboardsLeaderboardSortDirection.Descending,
        Ascending = Interop.PFLeaderboardsLeaderboardSortDirection.Ascending
    }

    /// <summary>
    /// ExternalFriendSources enum.
    /// </summary>
    public enum PFExternalFriendSources : uint
    {
        None = Interop.PFExternalFriendSources.None,
        Steam = Interop.PFExternalFriendSources.Steam,
        Facebook = Interop.PFExternalFriendSources.Facebook,
        Xbox = Interop.PFExternalFriendSources.Xbox,
        Psn = Interop.PFExternalFriendSources.Psn,
        All = Interop.PFExternalFriendSources.All
    }

    /// <summary>
    /// PFLeaderboardsLinkedStatisticColumn data model.
    /// </summary>
    public struct PFLeaderboardsLinkedStatisticColumn
    {
        /// <summary>
        /// The name of the statistic column that this leaderboard column is sourced from.
        /// </summary>
        public string LinkedStatisticColumnName;

        /// <summary>
        /// The name of the statistic.
        /// </summary>
        public string LinkedStatisticName;

        internal unsafe PFLeaderboardsLinkedStatisticColumn(Interop.PFLeaderboardsLinkedStatisticColumn interop)
        {

            LinkedStatisticColumnName = InteropWrapper.WrapperHelpers.InteropToString(interop.linkedStatisticColumnName)!;

            LinkedStatisticName = InteropWrapper.WrapperHelpers.InteropToString(interop.linkedStatisticName)!;

        }

        internal unsafe static void ToInterop(PFLeaderboardsLinkedStatisticColumn self, Interop.PFLeaderboardsLinkedStatisticColumn* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.LinkedStatisticColumnName, &interop->linkedStatisticColumnName, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.LinkedStatisticName, &interop->linkedStatisticName, buffer);

        }
            
    }

    /// <summary>
    /// PFLeaderboardsLeaderboardColumn data model.
    /// </summary>
    public struct PFLeaderboardsLeaderboardColumn
    {
        /// <summary>
        /// (Optional) If the value for this column is sourced from a statistic, details of the linked column.
        /// Null if the leaderboard is not linked.
        /// </summary>
        public PFLeaderboardsLinkedStatisticColumn? LinkedStatisticColumn;

        /// <summary>
        /// A name for the leaderboard column, unique per leaderboard definition.
        /// </summary>
        public string Name;

        /// <summary>
        /// The sort direction for this column.
        /// </summary>
        public PFLeaderboardsLeaderboardSortDirection SortDirection;

        internal unsafe PFLeaderboardsLeaderboardColumn(Interop.PFLeaderboardsLeaderboardColumn interop)
        {

            LinkedStatisticColumn = (interop.linkedStatisticColumn == null) ? null : new(*interop.linkedStatisticColumn);

            Name = InteropWrapper.WrapperHelpers.InteropToString(interop.name)!;

            SortDirection = (PFLeaderboardsLeaderboardSortDirection)(interop.sortDirection);

        }

        internal unsafe static void ToInterop(PFLeaderboardsLeaderboardColumn self, Interop.PFLeaderboardsLeaderboardColumn* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.LinkedStatisticColumn != null)
            {
                interop->linkedStatisticColumn = (Interop.PFLeaderboardsLinkedStatisticColumn*)buffer.AddBuffer(sizeof(Interop.PFLeaderboardsLinkedStatisticColumn));
                PFLeaderboardsLinkedStatisticColumn.ToInterop(self.LinkedStatisticColumn.Value, interop->linkedStatisticColumn, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

            interop->sortDirection = (Interop.PFLeaderboardsLeaderboardSortDirection)self.SortDirection;

        }
            
    }

    /// <summary>
    /// PFLeaderboardsLeaderboardEntityRankOnVersionEndConfig data model.
    /// </summary>
    public struct PFLeaderboardsLeaderboardEntityRankOnVersionEndConfig
    {
        /// <summary>
        /// The type of event to emit when the leaderboard version end.
        /// </summary>
        public PFEventType EventType;

        /// <summary>
        /// The maximum number of entity to return on leaderboard version end. Range is 1 to 1000.
        /// </summary>
        public int RankLimit;

        internal unsafe PFLeaderboardsLeaderboardEntityRankOnVersionEndConfig(Interop.PFLeaderboardsLeaderboardEntityRankOnVersionEndConfig interop)
        {

            EventType = (PFEventType)(interop.eventType);

            RankLimit = interop.rankLimit;

        }

        internal unsafe static void ToInterop(PFLeaderboardsLeaderboardEntityRankOnVersionEndConfig self, Interop.PFLeaderboardsLeaderboardEntityRankOnVersionEndConfig* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->eventType = (Interop.PFEventType)self.EventType;

            interop->rankLimit = self.RankLimit;

        }
            
    }

    /// <summary>
    /// PFLeaderboardsLeaderboardVersionEndConfig data model.
    /// </summary>
    public struct PFLeaderboardsLeaderboardVersionEndConfig
    {
        /// <summary>
        /// The type of event to emit when the leaderboard version end.
        /// </summary>
        public PFEventType EventType;

        internal unsafe PFLeaderboardsLeaderboardVersionEndConfig(Interop.PFLeaderboardsLeaderboardVersionEndConfig interop)
        {

            EventType = (PFEventType)(interop.eventType);

        }

        internal unsafe static void ToInterop(PFLeaderboardsLeaderboardVersionEndConfig self, Interop.PFLeaderboardsLeaderboardVersionEndConfig* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->eventType = (Interop.PFEventType)self.EventType;

        }
            
    }

    /// <summary>
    /// PFLeaderboardsLeaderboardEventEmissionConfig data model.
    /// </summary>
    public struct PFLeaderboardsLeaderboardEventEmissionConfig
    {
        /// <summary>
        /// (Optional) This event emits the top ranks of the leaderboard when the leaderboard version end.
        /// </summary>
        public PFLeaderboardsLeaderboardEntityRankOnVersionEndConfig? EntityRankOnVersionEndConfig;

        /// <summary>
        /// (Optional) This event is emitted when the leaderboard version end.
        /// </summary>
        public PFLeaderboardsLeaderboardVersionEndConfig? VersionEndConfig;

        internal unsafe PFLeaderboardsLeaderboardEventEmissionConfig(Interop.PFLeaderboardsLeaderboardEventEmissionConfig interop)
        {

            EntityRankOnVersionEndConfig = (interop.entityRankOnVersionEndConfig == null) ? null : new(*interop.entityRankOnVersionEndConfig);

            VersionEndConfig = (interop.versionEndConfig == null) ? null : new(*interop.versionEndConfig);

        }

        internal unsafe static void ToInterop(PFLeaderboardsLeaderboardEventEmissionConfig self, Interop.PFLeaderboardsLeaderboardEventEmissionConfig* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.EntityRankOnVersionEndConfig != null)
            {
                interop->entityRankOnVersionEndConfig = (Interop.PFLeaderboardsLeaderboardEntityRankOnVersionEndConfig*)buffer.AddBuffer(sizeof(Interop.PFLeaderboardsLeaderboardEntityRankOnVersionEndConfig));
                PFLeaderboardsLeaderboardEntityRankOnVersionEndConfig.ToInterop(self.EntityRankOnVersionEndConfig.Value, interop->entityRankOnVersionEndConfig, buffer);
            }

            if (self.VersionEndConfig != null)
            {
                interop->versionEndConfig = (Interop.PFLeaderboardsLeaderboardVersionEndConfig*)buffer.AddBuffer(sizeof(Interop.PFLeaderboardsLeaderboardVersionEndConfig));
                PFLeaderboardsLeaderboardVersionEndConfig.ToInterop(self.VersionEndConfig.Value, interop->versionEndConfig, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFLeaderboardsCreateLeaderboardDefinitionRequest data model.
    /// </summary>
    public struct PFLeaderboardsCreateLeaderboardDefinitionRequest
    {
        /// <summary>
        /// Leaderboard columns describing the sort directions, cannot be changed after creation. A maximum of
        /// 5 columns are allowed.
        /// </summary>
        public PFLeaderboardsLeaderboardColumn[] Columns;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The entity type being represented on the leaderboard. If it doesn't correspond to the PlayFab entity
        /// types, use 'external' as the type.
        /// </summary>
        public string EntityType;

        /// <summary>
        /// (Optional) [In Preview]: The configuration for the events emitted by this leaderboard. If not specified,
        /// no events will be emitted.
        /// </summary>
        public PFLeaderboardsLeaderboardEventEmissionConfig? EventEmissionConfig;

        /// <summary>
        /// A name for the leaderboard, unique per title.
        /// </summary>
        public string Name;

        /// <summary>
        /// Maximum number of entries on this leaderboard.
        /// </summary>
        public int SizeLimit;

        /// <summary>
        /// (Optional) The version reset configuration for the leaderboard definition.
        /// </summary>
        public PFVersionConfiguration? VersionConfiguration;

        internal unsafe static void ToInterop(PFLeaderboardsCreateLeaderboardDefinitionRequest self, Interop.PFLeaderboardsCreateLeaderboardDefinitionRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToInterop(self.Columns, &interop->columns, buffer, PFLeaderboardsLeaderboardColumn.ToInterop);
            interop->columnsCount = (uint)self.Columns.Length;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.EntityType, &interop->entityType, buffer);

            if (self.EventEmissionConfig != null)
            {
                interop->eventEmissionConfig = (Interop.PFLeaderboardsLeaderboardEventEmissionConfig*)buffer.AddBuffer(sizeof(Interop.PFLeaderboardsLeaderboardEventEmissionConfig));
                PFLeaderboardsLeaderboardEventEmissionConfig.ToInterop(self.EventEmissionConfig.Value, interop->eventEmissionConfig, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

            interop->sizeLimit = self.SizeLimit;

            if (self.VersionConfiguration != null)
            {
                interop->versionConfiguration = (Interop.PFVersionConfiguration*)buffer.AddBuffer(sizeof(Interop.PFVersionConfiguration));
                PFVersionConfiguration.ToInterop(self.VersionConfiguration.Value, interop->versionConfiguration, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFLeaderboardsDeleteLeaderboardDefinitionRequest data model.
    /// </summary>
    public struct PFLeaderboardsDeleteLeaderboardDefinitionRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The name of the leaderboard definition to delete.
        /// </summary>
        public string Name;

        internal unsafe static void ToInterop(PFLeaderboardsDeleteLeaderboardDefinitionRequest self, Interop.PFLeaderboardsDeleteLeaderboardDefinitionRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

        }
            
    }

    /// <summary>
    /// PFLeaderboardsDeleteLeaderboardEntriesRequest data model.
    /// </summary>
    public struct PFLeaderboardsDeleteLeaderboardEntriesRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The unique Ids of the entries to delete from the leaderboard.
        /// </summary>
        public string[]? EntityIds;

        /// <summary>
        /// The name of the leaderboard.
        /// </summary>
        public string Name;

        internal unsafe static void ToInterop(PFLeaderboardsDeleteLeaderboardEntriesRequest self, Interop.PFLeaderboardsDeleteLeaderboardEntriesRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.EntityIds != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.EntityIds, &interop->entityIds, buffer);
                interop->entityIdsCount = (uint)self.EntityIds.Length;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

        }
            
    }

    /// <summary>
    /// PFLeaderboardsGetFriendLeaderboardForEntityRequest data model.
    /// </summary>
    public struct PFLeaderboardsGetFriendLeaderboardForEntityRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) Indicates which other platforms' friends should be included in the response. In HTTP,
        /// it is represented as a comma-separated list of platforms.
        /// </summary>
        public PFExternalFriendSources? ExternalFriendSources;

        /// <summary>
        /// Name of the leaderboard.
        /// </summary>
        public string LeaderboardName;

        /// <summary>
        /// (Optional) Optional version of the leaderboard, defaults to current version.
        /// </summary>
        public uint? Version;

        /// <summary>
        /// (Optional) Xbox token if Xbox friends should be included. Requires Xbox be configured on PlayFab.
        /// </summary>
        public string? XboxToken;

        internal unsafe static void ToInterop(PFLeaderboardsGetFriendLeaderboardForEntityRequest self, Interop.PFLeaderboardsGetFriendLeaderboardForEntityRequest* interop, InteropWrapper.DisposableBuffer buffer)
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

            if (self.ExternalFriendSources != null)
            {
                *interop->externalFriendSources = (Interop.PFExternalFriendSources)self.ExternalFriendSources.Value;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.LeaderboardName, &interop->leaderboardName, buffer);

            if (self.Version != null)
            {
                *interop->version = self.Version.Value;
            }

            if (self.XboxToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.XboxToken, &interop->xboxToken, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFLeaderboardsEntityLeaderboardEntry data model. Individual rank of an entity in a leaderboard.
    /// </summary>
    public struct PFLeaderboardsEntityLeaderboardEntry
    {
        /// <summary>
        /// (Optional) Entity's display name.
        /// </summary>
        public string? DisplayName;

        /// <summary>
        /// (Optional) Entity identifier.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// The time at which the last update to the entry was recorded on the server.
        /// </summary>
        public long LastUpdated;

        /// <summary>
        /// (Optional) An opaque blob of data stored on the leaderboard entry. Note that the metadata is not
        /// used for ranking purposes.
        /// </summary>
        public string? Metadata;

        /// <summary>
        /// Position on the leaderboard.
        /// </summary>
        public int Rank;

        /// <summary>
        /// (Optional) Scores for the entry.
        /// </summary>
        public string[]? Scores;

        internal unsafe PFLeaderboardsEntityLeaderboardEntry(Interop.PFLeaderboardsEntityLeaderboardEntry interop)
        {

            DisplayName = (interop.displayName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.displayName);

            Entity = (interop.entity == null) ? null : new(*interop.entity);

            LastUpdated = interop.lastUpdated;

            Metadata = (interop.metadata == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.metadata);

            Rank = interop.rank;

            Scores = (interop.scores == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.scores, interop.scoresCount);

        }

        internal unsafe static void ToInterop(PFLeaderboardsEntityLeaderboardEntry self, Interop.PFLeaderboardsEntityLeaderboardEntry* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.DisplayName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DisplayName, &interop->displayName, buffer);
            }

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

            interop->lastUpdated = self.LastUpdated;

            if (self.Metadata != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Metadata, &interop->metadata, buffer);
            }

            interop->rank = self.Rank;

            if (self.Scores != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Scores, &interop->scores, buffer);
                interop->scoresCount = (uint)self.Scores.Length;
            }

        }
            
    }

    /// <summary>
    /// PFLeaderboardsGetEntityLeaderboardResponse data model. Leaderboard response.
    /// </summary>
    public struct PFLeaderboardsGetEntityLeaderboardResponse
    {
        /// <summary>
        /// (Optional) Leaderboard columns describing the sort directions.
        /// </summary>
        public PFLeaderboardsLeaderboardColumn[]? Columns;

        /// <summary>
        /// The number of entries on the leaderboard.
        /// </summary>
        public uint EntryCount;

        /// <summary>
        /// (Optional) The time the next scheduled reset will occur. Null if the leaderboard does not reset on
        /// a schedule.
        /// </summary>
        public long? NextReset;

        /// <summary>
        /// (Optional) Individual entity rankings in the leaderboard, in sorted order by rank.
        /// </summary>
        public PFLeaderboardsEntityLeaderboardEntry[]? Rankings;

        /// <summary>
        /// Version of the leaderboard being returned.
        /// </summary>
        public uint Version;

        internal unsafe PFLeaderboardsGetEntityLeaderboardResponse(Interop.PFLeaderboardsGetEntityLeaderboardResponse interop)
        {

            Columns = (interop.columns == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.columns, interop.columnsCount, elem => new PFLeaderboardsLeaderboardColumn(elem));

            EntryCount = interop.entryCount;

            NextReset = (interop.nextReset == null) ? null : *interop.nextReset;

            Rankings = (interop.rankings == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.rankings, interop.rankingsCount, elem => new PFLeaderboardsEntityLeaderboardEntry(elem));

            Version = interop.version;

        }
            
    }

    /// <summary>
    /// PFLeaderboardsGetEntityLeaderboardRequest data model. Request to load a leaderboard.
    /// </summary>
    public struct PFLeaderboardsGetEntityLeaderboardRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Name of the leaderboard.
        /// </summary>
        public string LeaderboardName;

        /// <summary>
        /// Maximum number of results to return from the leaderboard. Minimum 1, maximum 100.
        /// </summary>
        public uint PageSize;

        /// <summary>
        /// (Optional) Index position to start from. 1 is beginning of leaderboard. .
        /// </summary>
        public uint? StartingPosition;

        /// <summary>
        /// (Optional) Optional version of the leaderboard, defaults to current version.
        /// </summary>
        public uint? Version;

        internal unsafe static void ToInterop(PFLeaderboardsGetEntityLeaderboardRequest self, Interop.PFLeaderboardsGetEntityLeaderboardRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.LeaderboardName, &interop->leaderboardName, buffer);

            interop->pageSize = self.PageSize;

            if (self.StartingPosition != null)
            {
                *interop->startingPosition = self.StartingPosition.Value;
            }

            if (self.Version != null)
            {
                *interop->version = self.Version.Value;
            }

        }
            
    }

    /// <summary>
    /// PFLeaderboardsGetLeaderboardAroundEntityRequest data model. Request to load a section of a leaderboard
    /// centered on a specific entity.
    /// </summary>
    public struct PFLeaderboardsGetLeaderboardAroundEntityRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The optional entity to perform this action on. Defaults to the currently logged in entity.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// Name of the leaderboard.
        /// </summary>
        public string LeaderboardName;

        /// <summary>
        /// Number of surrounding entries to return (in addition to specified entity). In general, the number
        /// of ranks above and below will be split into half. For example, if the specified value is 10, 5 ranks
        /// above and 5 ranks below will be retrieved. However, the numbers will get skewed in either direction
        /// when the specified entity is towards the top or bottom of the leaderboard. Also, the number of entries
        /// returned can be lower than the value specified for entries at the bottom of the leaderboard.
        /// </summary>
        public uint MaxSurroundingEntries;

        /// <summary>
        /// (Optional) Optional version of the leaderboard, defaults to current.
        /// </summary>
        public uint? Version;

        internal unsafe static void ToInterop(PFLeaderboardsGetLeaderboardAroundEntityRequest self, Interop.PFLeaderboardsGetLeaderboardAroundEntityRequest* interop, InteropWrapper.DisposableBuffer buffer)
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

            InteropWrapper.WrapperHelpers.StringToInterop(self.LeaderboardName, &interop->leaderboardName, buffer);

            interop->maxSurroundingEntries = self.MaxSurroundingEntries;

            if (self.Version != null)
            {
                *interop->version = self.Version.Value;
            }

        }
            
    }

    /// <summary>
    /// PFLeaderboardsGetLeaderboardDefinitionRequest data model.
    /// </summary>
    public struct PFLeaderboardsGetLeaderboardDefinitionRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The name of the leaderboard to retrieve the definition for.
        /// </summary>
        public string Name;

        internal unsafe static void ToInterop(PFLeaderboardsGetLeaderboardDefinitionRequest self, Interop.PFLeaderboardsGetLeaderboardDefinitionRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

        }
            
    }

    /// <summary>
    /// PFLeaderboardsGetLeaderboardDefinitionResponse data model.
    /// </summary>
    public struct PFLeaderboardsGetLeaderboardDefinitionResponse
    {
        /// <summary>
        /// Sort direction of the leaderboard columns, cannot be changed after creation.
        /// </summary>
        public PFLeaderboardsLeaderboardColumn[] Columns;

        /// <summary>
        /// Created time, in UTC.
        /// </summary>
        public long Created;

        /// <summary>
        /// The entity type being represented on the leaderboard. If it doesn't correspond to the PlayFab entity
        /// types, use 'external' as the type.
        /// </summary>
        public string EntityType;

        /// <summary>
        /// (Optional) [In Preview]: The configuration for the events emitted by this leaderboard. If not specified,
        /// no events will be emitted.
        /// </summary>
        public PFLeaderboardsLeaderboardEventEmissionConfig? EventEmissionConfig;

        /// <summary>
        /// (Optional) Last time, in UTC, leaderboard version was incremented.
        /// </summary>
        public long? LastResetTime;

        /// <summary>
        /// A name for the leaderboard, unique per title.
        /// </summary>
        public string Name;

        /// <summary>
        /// Maximum number of entries on this leaderboard.
        /// </summary>
        public int SizeLimit;

        /// <summary>
        /// Latest Leaderboard version.
        /// </summary>
        public uint Version;

        /// <summary>
        /// The version reset configuration for the leaderboard definition.
        /// </summary>
        public PFVersionConfiguration VersionConfiguration;

        internal unsafe PFLeaderboardsGetLeaderboardDefinitionResponse(Interop.PFLeaderboardsGetLeaderboardDefinitionResponse interop)
        {

            Columns = InteropWrapper.WrapperHelpers.InteropToArray(*interop.columns, interop.columnsCount, elem => new PFLeaderboardsLeaderboardColumn(elem))!;

            Created = interop.created;

            EntityType = InteropWrapper.WrapperHelpers.InteropToString(interop.entityType)!;

            EventEmissionConfig = (interop.eventEmissionConfig == null) ? null : new(*interop.eventEmissionConfig);

            LastResetTime = (interop.lastResetTime == null) ? null : *interop.lastResetTime;

            Name = InteropWrapper.WrapperHelpers.InteropToString(interop.name)!;

            SizeLimit = interop.sizeLimit;

            Version = interop.version;

            VersionConfiguration = new(*interop.versionConfiguration);

        }
            
    }

    /// <summary>
    /// PFLeaderboardsGetLeaderboardForEntitiesRequest data model. Request a leaderboard limited to a collection
    /// of entities.
    /// </summary>
    public struct PFLeaderboardsGetLeaderboardForEntitiesRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Collection of Entity IDs to include in the leaderboard.
        /// </summary>
        public string[] EntityIds;

        /// <summary>
        /// Name of the leaderboard.
        /// </summary>
        public string LeaderboardName;

        /// <summary>
        /// (Optional) Optional version of the leaderboard, defaults to current.
        /// </summary>
        public uint? Version;

        internal unsafe static void ToInterop(PFLeaderboardsGetLeaderboardForEntitiesRequest self, Interop.PFLeaderboardsGetLeaderboardForEntitiesRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.EntityIds, &interop->entityIds, buffer);
            interop->entityIdsCount = (uint)self.EntityIds.Length;

            InteropWrapper.WrapperHelpers.StringToInterop(self.LeaderboardName, &interop->leaderboardName, buffer);

            if (self.Version != null)
            {
                *interop->version = self.Version.Value;
            }

        }
            
    }

    /// <summary>
    /// PFLeaderboardsIncrementLeaderboardVersionRequest data model.
    /// </summary>
    public struct PFLeaderboardsIncrementLeaderboardVersionRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The name of the leaderboard to increment the version for.
        /// </summary>
        public string Name;

        internal unsafe static void ToInterop(PFLeaderboardsIncrementLeaderboardVersionRequest self, Interop.PFLeaderboardsIncrementLeaderboardVersionRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

        }
            
    }

    /// <summary>
    /// PFLeaderboardsIncrementLeaderboardVersionResponse data model.
    /// </summary>
    public struct PFLeaderboardsIncrementLeaderboardVersionResponse
    {
        /// <summary>
        /// New Leaderboard version.
        /// </summary>
        public uint Version;

        internal unsafe PFLeaderboardsIncrementLeaderboardVersionResponse(Interop.PFLeaderboardsIncrementLeaderboardVersionResponse interop)
        {

            Version = interop.version;

        }
            
    }

    /// <summary>
    /// PFLeaderboardsListLeaderboardDefinitionsRequest data model.
    /// </summary>
    public struct PFLeaderboardsListLeaderboardDefinitionsRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        internal unsafe static void ToInterop(PFLeaderboardsListLeaderboardDefinitionsRequest self, Interop.PFLeaderboardsListLeaderboardDefinitionsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

        }
            
    }

    /// <summary>
    /// PFLeaderboardsLeaderboardDefinition data model.
    /// </summary>
    public struct PFLeaderboardsLeaderboardDefinition
    {
        /// <summary>
        /// Sort direction of the leaderboard columns, cannot be changed after creation.
        /// </summary>
        public PFLeaderboardsLeaderboardColumn[] Columns;

        /// <summary>
        /// Created time, in UTC.
        /// </summary>
        public long Created;

        /// <summary>
        /// The entity type being represented on the leaderboard. If it doesn't correspond to the PlayFab entity
        /// types, use 'external' as the type.
        /// </summary>
        public string EntityType;

        /// <summary>
        /// (Optional) [In Preview]: The configuration for the events emitted by this leaderboard. If not specified,
        /// no events will be emitted.
        /// </summary>
        public PFLeaderboardsLeaderboardEventEmissionConfig? EventEmissionConfig;

        /// <summary>
        /// (Optional) Last time, in UTC, leaderboard version was incremented.
        /// </summary>
        public long? LastResetTime;

        /// <summary>
        /// A name for the leaderboard, unique per title.
        /// </summary>
        public string Name;

        /// <summary>
        /// Maximum number of entries on this leaderboard.
        /// </summary>
        public int SizeLimit;

        /// <summary>
        /// Latest Leaderboard version.
        /// </summary>
        public uint Version;

        /// <summary>
        /// The version reset configuration for the leaderboard definition.
        /// </summary>
        public PFVersionConfiguration VersionConfiguration;

        internal unsafe PFLeaderboardsLeaderboardDefinition(Interop.PFLeaderboardsLeaderboardDefinition interop)
        {

            Columns = InteropWrapper.WrapperHelpers.InteropToArray(*interop.columns, interop.columnsCount, elem => new PFLeaderboardsLeaderboardColumn(elem))!;

            Created = interop.created;

            EntityType = InteropWrapper.WrapperHelpers.InteropToString(interop.entityType)!;

            EventEmissionConfig = (interop.eventEmissionConfig == null) ? null : new(*interop.eventEmissionConfig);

            LastResetTime = (interop.lastResetTime == null) ? null : *interop.lastResetTime;

            Name = InteropWrapper.WrapperHelpers.InteropToString(interop.name)!;

            SizeLimit = interop.sizeLimit;

            Version = interop.version;

            VersionConfiguration = new(*interop.versionConfiguration);

        }

        internal unsafe static void ToInterop(PFLeaderboardsLeaderboardDefinition self, Interop.PFLeaderboardsLeaderboardDefinition* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.ArrayToInterop(self.Columns, &interop->columns, buffer, PFLeaderboardsLeaderboardColumn.ToInterop);
            interop->columnsCount = (uint)self.Columns.Length;

            interop->created = self.Created;

            InteropWrapper.WrapperHelpers.StringToInterop(self.EntityType, &interop->entityType, buffer);

            if (self.EventEmissionConfig != null)
            {
                interop->eventEmissionConfig = (Interop.PFLeaderboardsLeaderboardEventEmissionConfig*)buffer.AddBuffer(sizeof(Interop.PFLeaderboardsLeaderboardEventEmissionConfig));
                PFLeaderboardsLeaderboardEventEmissionConfig.ToInterop(self.EventEmissionConfig.Value, interop->eventEmissionConfig, buffer);
            }

            if (self.LastResetTime != null)
            {
                *interop->lastResetTime = self.LastResetTime.Value;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

            interop->sizeLimit = self.SizeLimit;

            interop->version = self.Version;

            interop->versionConfiguration = (Interop.PFVersionConfiguration*)buffer.AddBuffer(sizeof(Interop.PFVersionConfiguration));
            PFVersionConfiguration.ToInterop(self.VersionConfiguration, interop->versionConfiguration, buffer);

        }
            
    }

    /// <summary>
    /// PFLeaderboardsListLeaderboardDefinitionsResponse data model.
    /// </summary>
    public struct PFLeaderboardsListLeaderboardDefinitionsResponse
    {
        /// <summary>
        /// (Optional) List of leaderboard definitions for the title.
        /// </summary>
        public PFLeaderboardsLeaderboardDefinition[]? LeaderboardDefinitions;

        internal unsafe PFLeaderboardsListLeaderboardDefinitionsResponse(Interop.PFLeaderboardsListLeaderboardDefinitionsResponse interop)
        {

            LeaderboardDefinitions = (interop.leaderboardDefinitions == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.leaderboardDefinitions, interop.leaderboardDefinitionsCount, elem => new PFLeaderboardsLeaderboardDefinition(elem));

        }
            
    }

    /// <summary>
    /// PFLeaderboardsUnlinkLeaderboardFromStatisticRequest data model.
    /// </summary>
    public struct PFLeaderboardsUnlinkLeaderboardFromStatisticRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// The name of the leaderboard definition to unlink.
        /// </summary>
        public string Name;

        /// <summary>
        /// The name of the statistic definition to unlink.
        /// </summary>
        public string StatisticName;

        internal unsafe static void ToInterop(PFLeaderboardsUnlinkLeaderboardFromStatisticRequest self, Interop.PFLeaderboardsUnlinkLeaderboardFromStatisticRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.StatisticName, &interop->statisticName, buffer);

        }
            
    }

    /// <summary>
    /// PFLeaderboardsUpdateLeaderboardDefinitionRequest data model.
    /// </summary>
    public struct PFLeaderboardsUpdateLeaderboardDefinitionRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) [In Preview]: The configuration for the events emitted by this leaderboard. If not specified,
        /// no events will be emitted.
        /// </summary>
        public PFLeaderboardsLeaderboardEventEmissionConfig? EventEmissionConfig;

        /// <summary>
        /// The name of the leaderboard to update the definition for.
        /// </summary>
        public string Name;

        /// <summary>
        /// (Optional) Maximum number of entries on this leaderboard.
        /// </summary>
        public int? SizeLimit;

        /// <summary>
        /// (Optional) The version reset configuration for the leaderboard definition.
        /// </summary>
        public PFVersionConfiguration? VersionConfiguration;

        internal unsafe static void ToInterop(PFLeaderboardsUpdateLeaderboardDefinitionRequest self, Interop.PFLeaderboardsUpdateLeaderboardDefinitionRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.EventEmissionConfig != null)
            {
                interop->eventEmissionConfig = (Interop.PFLeaderboardsLeaderboardEventEmissionConfig*)buffer.AddBuffer(sizeof(Interop.PFLeaderboardsLeaderboardEventEmissionConfig));
                PFLeaderboardsLeaderboardEventEmissionConfig.ToInterop(self.EventEmissionConfig.Value, interop->eventEmissionConfig, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

            if (self.SizeLimit != null)
            {
                *interop->sizeLimit = self.SizeLimit.Value;
            }

            if (self.VersionConfiguration != null)
            {
                interop->versionConfiguration = (Interop.PFVersionConfiguration*)buffer.AddBuffer(sizeof(Interop.PFVersionConfiguration));
                PFVersionConfiguration.ToInterop(self.VersionConfiguration.Value, interop->versionConfiguration, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFLeaderboardsLeaderboardEntryUpdate data model.
    /// </summary>
    public struct PFLeaderboardsLeaderboardEntryUpdate
    {
        /// <summary>
        /// The unique Id for the entry. If using PlayFab Entities, this would be the entityId of the entity.
        /// </summary>
        public string EntityId;

        /// <summary>
        /// (Optional) Arbitrary metadata to store along side the leaderboard entry, will be returned by all
        /// Leaderboard APIs. Must be less than 50 UTF8 encoded characters.
        /// </summary>
        public string? Metadata;

        /// <summary>
        /// (Optional) The scores for the leaderboard. The number of values provided here must match the number
        /// of columns in the Leaderboard definition.
        /// </summary>
        public string[]? Scores;

        internal unsafe PFLeaderboardsLeaderboardEntryUpdate(Interop.PFLeaderboardsLeaderboardEntryUpdate interop)
        {

            EntityId = InteropWrapper.WrapperHelpers.InteropToString(interop.entityId)!;

            Metadata = (interop.metadata == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.metadata);

            Scores = (interop.scores == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.scores, interop.scoresCount);

        }

        internal unsafe static void ToInterop(PFLeaderboardsLeaderboardEntryUpdate self, Interop.PFLeaderboardsLeaderboardEntryUpdate* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.EntityId, &interop->entityId, buffer);

            if (self.Metadata != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Metadata, &interop->metadata, buffer);
            }

            if (self.Scores != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Scores, &interop->scores, buffer);
                interop->scoresCount = (uint)self.Scores.Length;
            }

        }
            
    }

    /// <summary>
    /// PFLeaderboardsUpdateLeaderboardEntriesRequest data model.
    /// </summary>
    public struct PFLeaderboardsUpdateLeaderboardEntriesRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entries to add or update on the leaderboard.
        /// </summary>
        public PFLeaderboardsLeaderboardEntryUpdate[]? Entries;

        /// <summary>
        /// The name of the leaderboard.
        /// </summary>
        public string LeaderboardName;

        internal unsafe static void ToInterop(PFLeaderboardsUpdateLeaderboardEntriesRequest self, Interop.PFLeaderboardsUpdateLeaderboardEntriesRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.Entries != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Entries, &interop->entries, buffer, PFLeaderboardsLeaderboardEntryUpdate.ToInterop);
                interop->entriesCount = (uint)self.Entries.Length;
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.LeaderboardName, &interop->leaderboardName, buffer);

        }
            
    }

}
