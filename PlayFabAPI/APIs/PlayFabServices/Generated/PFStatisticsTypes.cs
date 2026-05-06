// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// StatisticAggregationMethod enum.
    /// </summary>
    public enum PFStatisticsStatisticAggregationMethod : uint
    {
        Last = Interop.PFStatisticsStatisticAggregationMethod.Last,
        Min = Interop.PFStatisticsStatisticAggregationMethod.Min,
        Max = Interop.PFStatisticsStatisticAggregationMethod.Max,
        Sum = Interop.PFStatisticsStatisticAggregationMethod.Sum
    }

    /// <summary>
    /// PFStatisticsStatisticColumn data model.
    /// </summary>
    public struct PFStatisticsStatisticColumn
    {
        /// <summary>
        /// Aggregation method for calculating new value of a statistic.
        /// </summary>
        public PFStatisticsStatisticAggregationMethod AggregationMethod;

        /// <summary>
        /// Name of the statistic column, as originally configured.
        /// </summary>
        public string Name;

        internal unsafe PFStatisticsStatisticColumn(Interop.PFStatisticsStatisticColumn interop)
        {

            AggregationMethod = (PFStatisticsStatisticAggregationMethod)(interop.aggregationMethod);

            Name = InteropWrapper.WrapperHelpers.InteropToString(interop.name)!;

        }

        internal unsafe static void ToInterop(PFStatisticsStatisticColumn self, Interop.PFStatisticsStatisticColumn* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->aggregationMethod = (Interop.PFStatisticsStatisticAggregationMethod)self.AggregationMethod;

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

        }
            
    }

    /// <summary>
    /// PFStatisticsStatisticsUpdateEventConfig data model.
    /// </summary>
    public struct PFStatisticsStatisticsUpdateEventConfig
    {
        /// <summary>
        /// The event type to emit when statistics are updated.
        /// </summary>
        public PFEventType EventType;

        internal unsafe PFStatisticsStatisticsUpdateEventConfig(Interop.PFStatisticsStatisticsUpdateEventConfig interop)
        {

            EventType = (PFEventType)(interop.eventType);

        }

        internal unsafe static void ToInterop(PFStatisticsStatisticsUpdateEventConfig self, Interop.PFStatisticsStatisticsUpdateEventConfig* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->eventType = (Interop.PFEventType)self.EventType;

        }
            
    }

    /// <summary>
    /// PFStatisticsStatisticsEventEmissionConfig data model.
    /// </summary>
    public struct PFStatisticsStatisticsEventEmissionConfig
    {
        /// <summary>
        /// (Optional) Emitted when statistics are updated.
        /// </summary>
        public PFStatisticsStatisticsUpdateEventConfig? UpdateEventConfig;

        internal unsafe PFStatisticsStatisticsEventEmissionConfig(Interop.PFStatisticsStatisticsEventEmissionConfig interop)
        {

            UpdateEventConfig = (interop.updateEventConfig == null) ? null : new(*interop.updateEventConfig);

        }

        internal unsafe static void ToInterop(PFStatisticsStatisticsEventEmissionConfig self, Interop.PFStatisticsStatisticsEventEmissionConfig* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.UpdateEventConfig != null)
            {
                interop->updateEventConfig = (Interop.PFStatisticsStatisticsUpdateEventConfig*)buffer.AddBuffer(sizeof(Interop.PFStatisticsStatisticsUpdateEventConfig));
                PFStatisticsStatisticsUpdateEventConfig.ToInterop(self.UpdateEventConfig.Value, interop->updateEventConfig, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFStatisticsCreateStatisticDefinitionRequest data model.
    /// </summary>
    public struct PFStatisticsCreateStatisticDefinitionRequest
    {
        /// <summary>
        /// (Optional) [In Preview]: The list of statistic definition names whose scores must be aggregated towards
        /// this stat. If AggregationSource is specified, the entityType of this definition MUST be Title (making
        /// it a CommunityStat). Currently, only one aggregation source can be specified.
        /// </summary>
        public string[]? AggregationSources;

        /// <summary>
        /// (Optional) The columns for the statistic defining the aggregation method for each column. A maximum
        /// of 5 columns are allowed.
        /// </summary>
        public PFStatisticsStatisticColumn[]? Columns;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The entity type allowed to have score(s) for this statistic.
        /// </summary>
        public string? EntityType;

        /// <summary>
        /// (Optional) [In Preview]: Configurations for different Statistics events that can be emitted by the
        /// service.
        /// </summary>
        public PFStatisticsStatisticsEventEmissionConfig? EventEmissionConfig;

        /// <summary>
        /// Name of the statistic. Must be less than 150 characters. Restricted to a-Z, 0-9, '(', ')', '_', '-'
        /// and '.'.
        /// </summary>
        public string Name;

        /// <summary>
        /// (Optional) The version reset configuration for the statistic definition.
        /// </summary>
        public PFVersionConfiguration? VersionConfiguration;

        internal unsafe static void ToInterop(PFStatisticsCreateStatisticDefinitionRequest self, Interop.PFStatisticsCreateStatisticDefinitionRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AggregationSources != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.AggregationSources, &interop->aggregationSources, buffer);
                interop->aggregationSourcesCount = (uint)self.AggregationSources.Length;
            }

            if (self.Columns != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Columns, &interop->columns, buffer, PFStatisticsStatisticColumn.ToInterop);
                interop->columnsCount = (uint)self.Columns.Length;
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.EntityType != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.EntityType, &interop->entityType, buffer);
            }

            if (self.EventEmissionConfig != null)
            {
                interop->eventEmissionConfig = (Interop.PFStatisticsStatisticsEventEmissionConfig*)buffer.AddBuffer(sizeof(Interop.PFStatisticsStatisticsEventEmissionConfig));
                PFStatisticsStatisticsEventEmissionConfig.ToInterop(self.EventEmissionConfig.Value, interop->eventEmissionConfig, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

            if (self.VersionConfiguration != null)
            {
                interop->versionConfiguration = (Interop.PFVersionConfiguration*)buffer.AddBuffer(sizeof(Interop.PFVersionConfiguration));
                PFVersionConfiguration.ToInterop(self.VersionConfiguration.Value, interop->versionConfiguration, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFStatisticsDeleteStatisticDefinitionRequest data model.
    /// </summary>
    public struct PFStatisticsDeleteStatisticDefinitionRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Name of the statistic to delete.
        /// </summary>
        public string Name;

        internal unsafe static void ToInterop(PFStatisticsDeleteStatisticDefinitionRequest self, Interop.PFStatisticsDeleteStatisticDefinitionRequest* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFStatisticsStatisticDelete data model.
    /// </summary>
    public struct PFStatisticsStatisticDelete
    {
        /// <summary>
        /// Name of the statistic, as originally configured.
        /// </summary>
        public string Name;

        internal unsafe PFStatisticsStatisticDelete(Interop.PFStatisticsStatisticDelete interop)
        {

            Name = InteropWrapper.WrapperHelpers.InteropToString(interop.name)!;

        }

        internal unsafe static void ToInterop(PFStatisticsStatisticDelete self, Interop.PFStatisticsStatisticDelete* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

        }
            
    }

    /// <summary>
    /// PFStatisticsDeleteStatisticsRequest data model.
    /// </summary>
    public struct PFStatisticsDeleteStatisticsRequest
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
        /// Collection of statistics to remove from this entity.
        /// </summary>
        public PFStatisticsStatisticDelete[] Statistics;

        internal unsafe static void ToInterop(PFStatisticsDeleteStatisticsRequest self, Interop.PFStatisticsDeleteStatisticsRequest* interop, InteropWrapper.DisposableBuffer buffer)
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

            InteropWrapper.WrapperHelpers.ArrayToInterop(self.Statistics, &interop->statistics, buffer, PFStatisticsStatisticDelete.ToInterop);
            interop->statisticsCount = (uint)self.Statistics.Length;

        }
            
    }

    /// <summary>
    /// PFStatisticsDeleteStatisticsResponse data model.
    /// </summary>
    public struct PFStatisticsDeleteStatisticsResponse
    {
        /// <summary>
        /// (Optional) The entity id and type.
        /// </summary>
        public PFEntityKey? Entity;

        internal unsafe PFStatisticsDeleteStatisticsResponse(Interop.PFStatisticsDeleteStatisticsResponse interop)
        {

            Entity = (interop.entity == null) ? null : new(*interop.entity);

        }
            
    }

    /// <summary>
    /// PFStatisticsGetStatisticDefinitionRequest data model.
    /// </summary>
    public struct PFStatisticsGetStatisticDefinitionRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Name of the statistic. Must be less than 150 characters.
        /// </summary>
        public string Name;

        internal unsafe static void ToInterop(PFStatisticsGetStatisticDefinitionRequest self, Interop.PFStatisticsGetStatisticDefinitionRequest* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFStatisticsGetStatisticDefinitionResponse data model.
    /// </summary>
    public struct PFStatisticsGetStatisticDefinitionResponse
    {
        /// <summary>
        /// (Optional) The list of statistic definitions names this definition aggregates to. .
        /// </summary>
        public string[]? AggregationDestinations;

        /// <summary>
        /// (Optional) The list of statistic definitions names whose values must be aggregated towards this stat.
        /// If AggregationSource is specified, the entityType of this definition MUST be Title (making it a CommunityStat).
        /// Currently, only one aggregation source can be specified.
        /// </summary>
        public string[]? AggregationSources;

        /// <summary>
        /// (Optional) The columns for the statistic defining the aggregation method for each column.
        /// </summary>
        public PFStatisticsStatisticColumn[]? Columns;

        /// <summary>
        /// Created time, in UTC.
        /// </summary>
        public long Created;

        /// <summary>
        /// (Optional) The entity type that can have this statistic.
        /// </summary>
        public string? EntityType;

        /// <summary>
        /// (Optional) [In Preview]: Configurations for different Statistics events that can be emitted by the
        /// service.
        /// </summary>
        public PFStatisticsStatisticsEventEmissionConfig? EventEmissionConfig;

        /// <summary>
        /// (Optional) Last time, in UTC, statistic version was incremented.
        /// </summary>
        public long? LastResetTime;

        /// <summary>
        /// (Optional) The list of leaderboards that are linked to this statistic definition.
        /// </summary>
        public string[]? LinkedLeaderboardNames;

        /// <summary>
        /// (Optional) Name of the statistic.
        /// </summary>
        public string? Name;

        /// <summary>
        /// Statistic version.
        /// </summary>
        public uint Version;

        /// <summary>
        /// (Optional) The version reset configuration for the leaderboard definition.
        /// </summary>
        public PFVersionConfiguration? VersionConfiguration;

        internal unsafe PFStatisticsGetStatisticDefinitionResponse(Interop.PFStatisticsGetStatisticDefinitionResponse interop)
        {

            AggregationDestinations = (interop.aggregationDestinations == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.aggregationDestinations, interop.aggregationDestinationsCount);

            AggregationSources = (interop.aggregationSources == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.aggregationSources, interop.aggregationSourcesCount);

            Columns = (interop.columns == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.columns, interop.columnsCount, elem => new PFStatisticsStatisticColumn(elem));

            Created = interop.created;

            EntityType = (interop.entityType == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.entityType);

            EventEmissionConfig = (interop.eventEmissionConfig == null) ? null : new(*interop.eventEmissionConfig);

            LastResetTime = (interop.lastResetTime == null) ? null : *interop.lastResetTime;

            LinkedLeaderboardNames = (interop.linkedLeaderboardNames == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.linkedLeaderboardNames, interop.linkedLeaderboardNamesCount);

            Name = (interop.name == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.name);

            Version = interop.version;

            VersionConfiguration = (interop.versionConfiguration == null) ? null : new(*interop.versionConfiguration);

        }
            
    }

    /// <summary>
    /// PFStatisticsGetStatisticsRequest data model.
    /// </summary>
    public struct PFStatisticsGetStatisticsRequest
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
        /// (Optional) The list of statistics to return for the user. If set to null, the current version of
        /// all statistics are returned.
        /// </summary>
        public string[]? StatisticNames;

        internal unsafe static void ToInterop(PFStatisticsGetStatisticsRequest self, Interop.PFStatisticsGetStatisticsRequest* interop, InteropWrapper.DisposableBuffer buffer)
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

            if (self.StatisticNames != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.StatisticNames, &interop->statisticNames, buffer);
                interop->statisticNamesCount = (uint)self.StatisticNames.Length;
            }

        }
            
    }

    /// <summary>
    /// PFStatisticsStatisticColumnCollection data model.
    /// </summary>
    public struct PFStatisticsStatisticColumnCollection
    {
        /// <summary>
        /// (Optional) Columns for the statistic defining the aggregation method for each column.
        /// </summary>
        public PFStatisticsStatisticColumn[]? Columns;

        internal unsafe PFStatisticsStatisticColumnCollection(Interop.PFStatisticsStatisticColumnCollection interop)
        {

            Columns = (interop.columns == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.columns, interop.columnsCount, elem => new PFStatisticsStatisticColumn(elem));

        }

        internal unsafe static void ToInterop(PFStatisticsStatisticColumnCollection self, Interop.PFStatisticsStatisticColumnCollection* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Columns != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Columns, &interop->columns, buffer, PFStatisticsStatisticColumn.ToInterop);
                interop->columnsCount = (uint)self.Columns.Length;
            }

        }
            
    }

    /// <summary>
    /// PFStatisticsEntityStatisticValue data model.
    /// </summary>
    public struct PFStatisticsEntityStatisticValue
    {
        /// <summary>
        /// (Optional) Metadata associated with the Statistic.
        /// </summary>
        public string? Metadata;

        /// <summary>
        /// (Optional) Statistic name.
        /// </summary>
        public string? Name;

        /// <summary>
        /// (Optional) Statistic scores.
        /// </summary>
        public string[]? Scores;

        /// <summary>
        /// Statistic version.
        /// </summary>
        public int Version;

        internal unsafe PFStatisticsEntityStatisticValue(Interop.PFStatisticsEntityStatisticValue interop)
        {

            Metadata = (interop.metadata == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.metadata);

            Name = (interop.name == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.name);

            Scores = (interop.scores == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.scores, interop.scoresCount);

            Version = interop.version;

        }

        internal unsafe static void ToInterop(PFStatisticsEntityStatisticValue self, Interop.PFStatisticsEntityStatisticValue* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Metadata != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Metadata, &interop->metadata, buffer);
            }

            if (self.Name != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);
            }

            if (self.Scores != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Scores, &interop->scores, buffer);
                interop->scoresCount = (uint)self.Scores.Length;
            }

            interop->version = self.Version;

        }
            
    }

    /// <summary>
    /// PFStatisticsGetStatisticsResponse data model.
    /// </summary>
    public struct PFStatisticsGetStatisticsResponse
    {
        /// <summary>
        /// (Optional) A mapping of statistic name to the columns defined in the corresponding definition.
        /// </summary>
        public Dictionary<string, PFStatisticsStatisticColumnCollection>? ColumnDetails;

        /// <summary>
        /// (Optional) The entity id and type.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) List of statistics keyed by Name. Only the latest version of a statistic is returned.
        /// </summary>
        public Dictionary<string, PFStatisticsEntityStatisticValue>? Statistics;

        internal unsafe PFStatisticsGetStatisticsResponse(Interop.PFStatisticsGetStatisticsResponse interop)
        {

            ColumnDetails = (interop.columnDetails == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.columnDetails, interop.columnDetailsCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFStatisticsStatisticColumnCollection(*pair.value)));

            Entity = (interop.entity == null) ? null : new(*interop.entity);

            Statistics = (interop.statistics == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.statistics, interop.statisticsCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFStatisticsEntityStatisticValue(*pair.value)));

        }
            
    }

    /// <summary>
    /// PFStatisticsGetStatisticsForEntitiesRequest data model.
    /// </summary>
    public struct PFStatisticsGetStatisticsForEntitiesRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Collection of Entity IDs to retrieve statistics for.
        /// </summary>
        public PFEntityKey[] Entities;

        /// <summary>
        /// (Optional) The list of statistics to return for the user. If set to null, the current version of
        /// all statistics are returned.
        /// </summary>
        public string[]? StatisticNames;

        internal unsafe static void ToInterop(PFStatisticsGetStatisticsForEntitiesRequest self, Interop.PFStatisticsGetStatisticsForEntitiesRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            InteropWrapper.WrapperHelpers.ArrayToInterop(self.Entities, &interop->entities, buffer, PFEntityKey.ToInterop);
            interop->entitiesCount = (uint)self.Entities.Length;

            if (self.StatisticNames != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.StatisticNames, &interop->statisticNames, buffer);
                interop->statisticNamesCount = (uint)self.StatisticNames.Length;
            }

        }
            
    }

    /// <summary>
    /// PFStatisticsEntityStatistics data model.
    /// </summary>
    public struct PFStatisticsEntityStatistics
    {
        /// <summary>
        /// (Optional) The entity for which the statistics are returned.
        /// </summary>
        public PFEntityKey? EntityKey;

        /// <summary>
        /// (Optional) The statistics for the given entity key.
        /// </summary>
        public PFStatisticsEntityStatisticValue[]? Statistics;

        internal unsafe PFStatisticsEntityStatistics(Interop.PFStatisticsEntityStatistics interop)
        {

            EntityKey = (interop.entityKey == null) ? null : new(*interop.entityKey);

            Statistics = (interop.statistics == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.statistics, interop.statisticsCount, elem => new PFStatisticsEntityStatisticValue(elem));

        }

        internal unsafe static void ToInterop(PFStatisticsEntityStatistics self, Interop.PFStatisticsEntityStatistics* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.EntityKey != null)
            {
                interop->entityKey = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.EntityKey.Value, interop->entityKey, buffer);
            }

            if (self.Statistics != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Statistics, &interop->statistics, buffer, PFStatisticsEntityStatisticValue.ToInterop);
                interop->statisticsCount = (uint)self.Statistics.Length;
            }

        }
            
    }

    /// <summary>
    /// PFStatisticsGetStatisticsForEntitiesResponse data model.
    /// </summary>
    public struct PFStatisticsGetStatisticsForEntitiesResponse
    {
        /// <summary>
        /// (Optional) A mapping of statistic name to the columns defined in the corresponding definition.
        /// </summary>
        public Dictionary<string, PFStatisticsStatisticColumnCollection>? ColumnDetails;

        /// <summary>
        /// (Optional) List of entities mapped to their statistics. Only the latest version of a statistic is
        /// returned.
        /// </summary>
        public PFStatisticsEntityStatistics[]? EntitiesStatistics;

        internal unsafe PFStatisticsGetStatisticsForEntitiesResponse(Interop.PFStatisticsGetStatisticsForEntitiesResponse interop)
        {

            ColumnDetails = (interop.columnDetails == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.columnDetails, interop.columnDetailsCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFStatisticsStatisticColumnCollection(*pair.value)));

            EntitiesStatistics = (interop.entitiesStatistics == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.entitiesStatistics, interop.entitiesStatisticsCount, elem => new PFStatisticsEntityStatistics(elem));

        }
            
    }

    /// <summary>
    /// PFStatisticsIncrementStatisticVersionRequest data model.
    /// </summary>
    public struct PFStatisticsIncrementStatisticVersionRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// Name of the statistic to increment the version of.
        /// </summary>
        public string Name;

        internal unsafe static void ToInterop(PFStatisticsIncrementStatisticVersionRequest self, Interop.PFStatisticsIncrementStatisticVersionRequest* interop, InteropWrapper.DisposableBuffer buffer)
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
    /// PFStatisticsIncrementStatisticVersionResponse data model.
    /// </summary>
    public struct PFStatisticsIncrementStatisticVersionResponse
    {
        /// <summary>
        /// New statistic version.
        /// </summary>
        public uint Version;

        internal unsafe PFStatisticsIncrementStatisticVersionResponse(Interop.PFStatisticsIncrementStatisticVersionResponse interop)
        {

            Version = interop.version;

        }
            
    }

    /// <summary>
    /// PFStatisticsListStatisticDefinitionsRequest data model.
    /// </summary>
    public struct PFStatisticsListStatisticDefinitionsRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) The page size for the request.
        /// </summary>
        public int? PageSize;

        /// <summary>
        /// (Optional) The skip token for the paged request.
        /// </summary>
        public string? SkipToken;

        internal unsafe static void ToInterop(PFStatisticsListStatisticDefinitionsRequest self, Interop.PFStatisticsListStatisticDefinitionsRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.PageSize != null)
            {
                *interop->pageSize = self.PageSize.Value;
            }

            if (self.SkipToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.SkipToken, &interop->skipToken, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFStatisticsStatisticDefinition data model.
    /// </summary>
    public struct PFStatisticsStatisticDefinition
    {
        /// <summary>
        /// (Optional) The list of statistic definitions names this definition aggregates to. .
        /// </summary>
        public string[]? AggregationDestinations;

        /// <summary>
        /// (Optional) The list of statistic definitions names whose values must be aggregated towards this stat.
        /// If AggregationSource is specified, the entityType of this definition MUST be Title (making it a CommunityStat).
        /// Currently, only one aggregation source can be specified.
        /// </summary>
        public string[]? AggregationSources;

        /// <summary>
        /// (Optional) The columns for the statistic defining the aggregation method for each column.
        /// </summary>
        public PFStatisticsStatisticColumn[]? Columns;

        /// <summary>
        /// Created time, in UTC.
        /// </summary>
        public long Created;

        /// <summary>
        /// (Optional) The entity type that can have this statistic.
        /// </summary>
        public string? EntityType;

        /// <summary>
        /// (Optional) [In Preview]: Configurations for different Statistics events that can be emitted by the
        /// service.
        /// </summary>
        public PFStatisticsStatisticsEventEmissionConfig? EventEmissionConfig;

        /// <summary>
        /// (Optional) Last time, in UTC, statistic version was incremented.
        /// </summary>
        public long? LastResetTime;

        /// <summary>
        /// (Optional) The list of leaderboards that are linked to this statistic definition.
        /// </summary>
        public string[]? LinkedLeaderboardNames;

        /// <summary>
        /// (Optional) Name of the statistic.
        /// </summary>
        public string? Name;

        /// <summary>
        /// Statistic version.
        /// </summary>
        public uint Version;

        /// <summary>
        /// (Optional) The version reset configuration for the leaderboard definition.
        /// </summary>
        public PFVersionConfiguration? VersionConfiguration;

        internal unsafe PFStatisticsStatisticDefinition(Interop.PFStatisticsStatisticDefinition interop)
        {

            AggregationDestinations = (interop.aggregationDestinations == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.aggregationDestinations, interop.aggregationDestinationsCount);

            AggregationSources = (interop.aggregationSources == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.aggregationSources, interop.aggregationSourcesCount);

            Columns = (interop.columns == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.columns, interop.columnsCount, elem => new PFStatisticsStatisticColumn(elem));

            Created = interop.created;

            EntityType = (interop.entityType == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.entityType);

            EventEmissionConfig = (interop.eventEmissionConfig == null) ? null : new(*interop.eventEmissionConfig);

            LastResetTime = (interop.lastResetTime == null) ? null : *interop.lastResetTime;

            LinkedLeaderboardNames = (interop.linkedLeaderboardNames == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.linkedLeaderboardNames, interop.linkedLeaderboardNamesCount);

            Name = (interop.name == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.name);

            Version = interop.version;

            VersionConfiguration = (interop.versionConfiguration == null) ? null : new(*interop.versionConfiguration);

        }

        internal unsafe static void ToInterop(PFStatisticsStatisticDefinition self, Interop.PFStatisticsStatisticDefinition* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AggregationDestinations != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.AggregationDestinations, &interop->aggregationDestinations, buffer);
                interop->aggregationDestinationsCount = (uint)self.AggregationDestinations.Length;
            }

            if (self.AggregationSources != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.AggregationSources, &interop->aggregationSources, buffer);
                interop->aggregationSourcesCount = (uint)self.AggregationSources.Length;
            }

            if (self.Columns != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Columns, &interop->columns, buffer, PFStatisticsStatisticColumn.ToInterop);
                interop->columnsCount = (uint)self.Columns.Length;
            }

            interop->created = self.Created;

            if (self.EntityType != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.EntityType, &interop->entityType, buffer);
            }

            if (self.EventEmissionConfig != null)
            {
                interop->eventEmissionConfig = (Interop.PFStatisticsStatisticsEventEmissionConfig*)buffer.AddBuffer(sizeof(Interop.PFStatisticsStatisticsEventEmissionConfig));
                PFStatisticsStatisticsEventEmissionConfig.ToInterop(self.EventEmissionConfig.Value, interop->eventEmissionConfig, buffer);
            }

            if (self.LastResetTime != null)
            {
                *interop->lastResetTime = self.LastResetTime.Value;
            }

            if (self.LinkedLeaderboardNames != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.LinkedLeaderboardNames, &interop->linkedLeaderboardNames, buffer);
                interop->linkedLeaderboardNamesCount = (uint)self.LinkedLeaderboardNames.Length;
            }

            if (self.Name != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);
            }

            interop->version = self.Version;

            if (self.VersionConfiguration != null)
            {
                interop->versionConfiguration = (Interop.PFVersionConfiguration*)buffer.AddBuffer(sizeof(Interop.PFVersionConfiguration));
                PFVersionConfiguration.ToInterop(self.VersionConfiguration.Value, interop->versionConfiguration, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFStatisticsListStatisticDefinitionsResponse data model.
    /// </summary>
    public struct PFStatisticsListStatisticDefinitionsResponse
    {
        /// <summary>
        /// The page size on the response.
        /// </summary>
        public int PageSize;

        /// <summary>
        /// (Optional) The skip token for the paged response.
        /// </summary>
        public string? SkipToken;

        /// <summary>
        /// (Optional) List of statistic definitions for the title.
        /// </summary>
        public PFStatisticsStatisticDefinition[]? StatisticDefinitions;

        internal unsafe PFStatisticsListStatisticDefinitionsResponse(Interop.PFStatisticsListStatisticDefinitionsResponse interop)
        {

            PageSize = interop.pageSize;

            SkipToken = (interop.skipToken == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.skipToken);

            StatisticDefinitions = (interop.statisticDefinitions == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.statisticDefinitions, interop.statisticDefinitionsCount, elem => new PFStatisticsStatisticDefinition(elem));

        }
            
    }

    /// <summary>
    /// PFStatisticsUpdateStatisticDefinitionRequest data model.
    /// </summary>
    public struct PFStatisticsUpdateStatisticDefinitionRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) [In Preview]: Configurations for different Statistics events that can be emitted by the
        /// service.
        /// </summary>
        public PFStatisticsStatisticsEventEmissionConfig? EventEmissionConfig;

        /// <summary>
        /// Name of the statistic. Must be less than 150 characters. Restricted to a-Z, 0-9, '(', ')', '_', '-'
        /// and '.'.
        /// </summary>
        public string Name;

        /// <summary>
        /// (Optional) The version reset configuration for the statistic definition.
        /// </summary>
        public PFVersionConfiguration? VersionConfiguration;

        internal unsafe static void ToInterop(PFStatisticsUpdateStatisticDefinitionRequest self, Interop.PFStatisticsUpdateStatisticDefinitionRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.EventEmissionConfig != null)
            {
                interop->eventEmissionConfig = (Interop.PFStatisticsStatisticsEventEmissionConfig*)buffer.AddBuffer(sizeof(Interop.PFStatisticsStatisticsEventEmissionConfig));
                PFStatisticsStatisticsEventEmissionConfig.ToInterop(self.EventEmissionConfig.Value, interop->eventEmissionConfig, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

            if (self.VersionConfiguration != null)
            {
                interop->versionConfiguration = (Interop.PFVersionConfiguration*)buffer.AddBuffer(sizeof(Interop.PFVersionConfiguration));
                PFVersionConfiguration.ToInterop(self.VersionConfiguration.Value, interop->versionConfiguration, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFStatisticsStatisticUpdate data model.
    /// </summary>
    public struct PFStatisticsStatisticUpdate
    {
        /// <summary>
        /// (Optional) Arbitrary metadata to store along side the statistic, will be returned by all Leaderboard
        /// APIs.
        /// </summary>
        public string? Metadata;

        /// <summary>
        /// Name of the statistic, as originally configured.
        /// </summary>
        public string Name;

        /// <summary>
        /// (Optional) Statistic scores for the entity. This will be used in accordance with the aggregation
        /// method configured for the statistics.The maximum value allowed for each individual score is 9223372036854775807.
        /// The minimum value for each individual score is -9223372036854775807The values are formatted as strings
        /// to avoid interop issues with client libraries unable to handle 64bit integers.
        /// </summary>
        public string[]? Scores;

        /// <summary>
        /// (Optional) Optional field to indicate the version of the statistic to set. When empty defaults to
        /// the statistic's current version.
        /// </summary>
        public uint? Version;

        internal unsafe PFStatisticsStatisticUpdate(Interop.PFStatisticsStatisticUpdate interop)
        {

            Metadata = (interop.metadata == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.metadata);

            Name = InteropWrapper.WrapperHelpers.InteropToString(interop.name)!;

            Scores = (interop.scores == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.scores, interop.scoresCount);

            Version = (interop.version == null) ? null : *interop.version;

        }

        internal unsafe static void ToInterop(PFStatisticsStatisticUpdate self, Interop.PFStatisticsStatisticUpdate* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Metadata != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Metadata, &interop->metadata, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

            if (self.Scores != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Scores, &interop->scores, buffer);
                interop->scoresCount = (uint)self.Scores.Length;
            }

            if (self.Version != null)
            {
                *interop->version = self.Version.Value;
            }

        }
            
    }

    /// <summary>
    /// PFStatisticsUpdateStatisticsRequest data model.
    /// </summary>
    public struct PFStatisticsUpdateStatisticsRequest
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
        /// Collection of statistics to update, maximum 50.
        /// </summary>
        public PFStatisticsStatisticUpdate[] Statistics;

        /// <summary>
        /// (Optional) Optional transactionId of this update which can be used to ensure idempotence.
        /// </summary>
        public string? TransactionId;

        internal unsafe static void ToInterop(PFStatisticsUpdateStatisticsRequest self, Interop.PFStatisticsUpdateStatisticsRequest* interop, InteropWrapper.DisposableBuffer buffer)
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

            InteropWrapper.WrapperHelpers.ArrayToInterop(self.Statistics, &interop->statistics, buffer, PFStatisticsStatisticUpdate.ToInterop);
            interop->statisticsCount = (uint)self.Statistics.Length;

            if (self.TransactionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TransactionId, &interop->transactionId, buffer);
            }

        }
            
    }

    /// <summary>
    /// PFStatisticsUpdateStatisticsResponse data model.
    /// </summary>
    public struct PFStatisticsUpdateStatisticsResponse
    {
        /// <summary>
        /// (Optional) A mapping of statistic name to the columns defined in the corresponding definition.
        /// </summary>
        public Dictionary<string, PFStatisticsStatisticColumnCollection>? ColumnDetails;

        /// <summary>
        /// (Optional) The entity id and type.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// (Optional) Updated entity profile statistics.
        /// </summary>
        public Dictionary<string, PFStatisticsEntityStatisticValue>? Statistics;

        internal unsafe PFStatisticsUpdateStatisticsResponse(Interop.PFStatisticsUpdateStatisticsResponse interop)
        {

            ColumnDetails = (interop.columnDetails == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.columnDetails, interop.columnDetailsCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFStatisticsStatisticColumnCollection(*pair.value)));

            Entity = (interop.entity == null) ? null : new(*interop.entity);

            Statistics = (interop.statistics == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.statistics, interop.statisticsCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFStatisticsEntityStatisticValue(*pair.value)));

        }
            
    }

}
