// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// AzureVmSize enum.
    /// </summary>
    public enum PFMultiplayerServerAzureVmSize : uint
    {
        Standard_A1 = Interop.PFMultiplayerServerAzureVmSize.Standard_A1,
        Standard_A2 = Interop.PFMultiplayerServerAzureVmSize.Standard_A2,
        Standard_A3 = Interop.PFMultiplayerServerAzureVmSize.Standard_A3,
        Standard_A4 = Interop.PFMultiplayerServerAzureVmSize.Standard_A4,
        Standard_A1_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_A1_v2,
        Standard_A2_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_A2_v2,
        Standard_A4_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_A4_v2,
        Standard_A8_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_A8_v2,
        Standard_D1_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_D1_v2,
        Standard_D2_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_D2_v2,
        Standard_D3_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_D3_v2,
        Standard_D4_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_D4_v2,
        Standard_D5_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_D5_v2,
        Standard_D2_v3 = Interop.PFMultiplayerServerAzureVmSize.Standard_D2_v3,
        Standard_D4_v3 = Interop.PFMultiplayerServerAzureVmSize.Standard_D4_v3,
        Standard_D8_v3 = Interop.PFMultiplayerServerAzureVmSize.Standard_D8_v3,
        Standard_D16_v3 = Interop.PFMultiplayerServerAzureVmSize.Standard_D16_v3,
        Standard_F1 = Interop.PFMultiplayerServerAzureVmSize.Standard_F1,
        Standard_F2 = Interop.PFMultiplayerServerAzureVmSize.Standard_F2,
        Standard_F4 = Interop.PFMultiplayerServerAzureVmSize.Standard_F4,
        Standard_F8 = Interop.PFMultiplayerServerAzureVmSize.Standard_F8,
        Standard_F16 = Interop.PFMultiplayerServerAzureVmSize.Standard_F16,
        Standard_F2s_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_F2s_v2,
        Standard_F4s_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_F4s_v2,
        Standard_F8s_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_F8s_v2,
        Standard_F16s_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_F16s_v2,
        Standard_D2as_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_D2as_v4,
        Standard_D4as_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_D4as_v4,
        Standard_D8as_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_D8as_v4,
        Standard_D16as_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_D16as_v4,
        Standard_D2a_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_D2a_v4,
        Standard_D4a_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_D4a_v4,
        Standard_D8a_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_D8a_v4,
        Standard_D16a_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_D16a_v4,
        Standard_D2ads_v5 = Interop.PFMultiplayerServerAzureVmSize.Standard_D2ads_v5,
        Standard_D4ads_v5 = Interop.PFMultiplayerServerAzureVmSize.Standard_D4ads_v5,
        Standard_D8ads_v5 = Interop.PFMultiplayerServerAzureVmSize.Standard_D8ads_v5,
        Standard_D16ads_v5 = Interop.PFMultiplayerServerAzureVmSize.Standard_D16ads_v5,
        Standard_D2ads_v6 = Interop.PFMultiplayerServerAzureVmSize.Standard_D2ads_v6,
        Standard_D4ads_v6 = Interop.PFMultiplayerServerAzureVmSize.Standard_D4ads_v6,
        Standard_D8ads_v6 = Interop.PFMultiplayerServerAzureVmSize.Standard_D8ads_v6,
        Standard_D16ads_v6 = Interop.PFMultiplayerServerAzureVmSize.Standard_D16ads_v6,
        Standard_E2a_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_E2a_v4,
        Standard_E4a_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_E4a_v4,
        Standard_E8a_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_E8a_v4,
        Standard_E16a_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_E16a_v4,
        Standard_E2as_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_E2as_v4,
        Standard_E4as_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_E4as_v4,
        Standard_E8as_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_E8as_v4,
        Standard_E16as_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_E16as_v4,
        Standard_D2s_v3 = Interop.PFMultiplayerServerAzureVmSize.Standard_D2s_v3,
        Standard_D4s_v3 = Interop.PFMultiplayerServerAzureVmSize.Standard_D4s_v3,
        Standard_D8s_v3 = Interop.PFMultiplayerServerAzureVmSize.Standard_D8s_v3,
        Standard_D16s_v3 = Interop.PFMultiplayerServerAzureVmSize.Standard_D16s_v3,
        Standard_DS1_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_DS1_v2,
        Standard_DS2_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_DS2_v2,
        Standard_DS3_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_DS3_v2,
        Standard_DS4_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_DS4_v2,
        Standard_DS5_v2 = Interop.PFMultiplayerServerAzureVmSize.Standard_DS5_v2,
        Standard_NC4as_T4_v3 = Interop.PFMultiplayerServerAzureVmSize.Standard_NC4as_T4_v3,
        Standard_D2d_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_D2d_v4,
        Standard_D4d_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_D4d_v4,
        Standard_D8d_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_D8d_v4,
        Standard_D16d_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_D16d_v4,
        Standard_D2ds_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_D2ds_v4,
        Standard_D4ds_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_D4ds_v4,
        Standard_D8ds_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_D8ds_v4,
        Standard_D16ds_v4 = Interop.PFMultiplayerServerAzureVmSize.Standard_D16ds_v4,
        Standard_HB120_16rs_v3 = Interop.PFMultiplayerServerAzureVmSize.Standard_HB120_16rs_v3,
        Standard_HB120_32rs_v3 = Interop.PFMultiplayerServerAzureVmSize.Standard_HB120_32rs_v3,
        Standard_HB120_64rs_v3 = Interop.PFMultiplayerServerAzureVmSize.Standard_HB120_64rs_v3,
        Standard_HB120_96rs_v3 = Interop.PFMultiplayerServerAzureVmSize.Standard_HB120_96rs_v3,
        Standard_HB120rs_v3 = Interop.PFMultiplayerServerAzureVmSize.Standard_HB120rs_v3,
        Standard_D2d_v5 = Interop.PFMultiplayerServerAzureVmSize.Standard_D2d_v5,
        Standard_D4d_v5 = Interop.PFMultiplayerServerAzureVmSize.Standard_D4d_v5,
        Standard_D8d_v5 = Interop.PFMultiplayerServerAzureVmSize.Standard_D8d_v5,
        Standard_D16d_v5 = Interop.PFMultiplayerServerAzureVmSize.Standard_D16d_v5,
        Standard_D32d_v5 = Interop.PFMultiplayerServerAzureVmSize.Standard_D32d_v5,
        Standard_D2ds_v5 = Interop.PFMultiplayerServerAzureVmSize.Standard_D2ds_v5,
        Standard_D4ds_v5 = Interop.PFMultiplayerServerAzureVmSize.Standard_D4ds_v5,
        Standard_D8ds_v5 = Interop.PFMultiplayerServerAzureVmSize.Standard_D8ds_v5,
        Standard_D16ds_v5 = Interop.PFMultiplayerServerAzureVmSize.Standard_D16ds_v5,
        Standard_D32ds_v5 = Interop.PFMultiplayerServerAzureVmSize.Standard_D32ds_v5,
        Standard_D2ds_v6 = Interop.PFMultiplayerServerAzureVmSize.Standard_D2ds_v6,
        Standard_D4ds_v6 = Interop.PFMultiplayerServerAzureVmSize.Standard_D4ds_v6,
        Standard_D8ds_v6 = Interop.PFMultiplayerServerAzureVmSize.Standard_D8ds_v6,
        Standard_D16ds_v6 = Interop.PFMultiplayerServerAzureVmSize.Standard_D16ds_v6
    }

    /// <summary>
    /// ProtocolType enum.
    /// </summary>
    public enum PFMultiplayerServerProtocolType : uint
    {
        TCP = Interop.PFMultiplayerServerProtocolType.TCP,
        UDP = Interop.PFMultiplayerServerProtocolType.UDP
    }

    /// <summary>
    /// PFMultiplayerServerListBuildAliasesRequest data model. Returns a list of summarized details of all
    /// multiplayer server builds for a title.
    /// </summary>
    public struct PFMultiplayerServerListBuildAliasesRequest
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

        internal unsafe static void ToInterop(PFMultiplayerServerListBuildAliasesRequest self, Interop.PFMultiplayerServerListBuildAliasesRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.PageSize != null)
            {
                interop->pageSize = (int*)buffer.AddBuffer(sizeof(int));
                *interop->pageSize = self.PageSize.Value;
            }

            if (self.SkipToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.SkipToken, &interop->skipToken, buffer);
            }

        }
    }

    /// <summary>
    /// PFMultiplayerServerBuildSelectionCriterion data model.
    /// </summary>
    public struct PFMultiplayerServerBuildSelectionCriterion
    {
        /// <summary>
        /// (Optional) Dictionary of build ids and their respective weights for distribution of allocation requests.
        /// </summary>
        public Dictionary<string, uint>? BuildWeightDistribution;

        internal unsafe PFMultiplayerServerBuildSelectionCriterion(Interop.PFMultiplayerServerBuildSelectionCriterion interop)
        {

            BuildWeightDistribution = (interop.buildWeightDistribution == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.buildWeightDistribution, interop.buildWeightDistributionCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), pair.value));

        }

        internal unsafe static void ToInterop(PFMultiplayerServerBuildSelectionCriterion self, Interop.PFMultiplayerServerBuildSelectionCriterion* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.BuildWeightDistribution != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToInterop(self.BuildWeightDistribution, &interop->buildWeightDistribution, buffer, (KeyValuePair<string, uint> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    return new Interop.PFUint32DictionaryEntry{ key = keyBuf, value = pair.Value };
                });
                interop->buildWeightDistributionCount = (uint)self.BuildWeightDistribution.Count;
            }

        }
    }

    /// <summary>
    /// PFMultiplayerServerBuildAliasDetailsResponse data model.
    /// </summary>
    public struct PFMultiplayerServerBuildAliasDetailsResponse
    {
        /// <summary>
        /// (Optional) The guid string alias Id of the alias to be created or updated.
        /// </summary>
        public string? AliasId;

        /// <summary>
        /// (Optional) The alias name.
        /// </summary>
        public string? AliasName;

        /// <summary>
        /// (Optional) Array of build selection criteria.
        /// </summary>
        public PFMultiplayerServerBuildSelectionCriterion[]? BuildSelectionCriteria;

        internal unsafe PFMultiplayerServerBuildAliasDetailsResponse(Interop.PFMultiplayerServerBuildAliasDetailsResponse interop)
        {

            AliasId = (interop.aliasId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.aliasId);

            AliasName = (interop.aliasName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.aliasName);

            BuildSelectionCriteria = (interop.buildSelectionCriteria == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.buildSelectionCriteria, interop.buildSelectionCriteriaCount, elem => new PFMultiplayerServerBuildSelectionCriterion(elem));

        }
    }

    /// <summary>
    /// PFMultiplayerServerListBuildAliasesResponse data model.
    /// </summary>
    public struct PFMultiplayerServerListBuildAliasesResponse
    {
        /// <summary>
        /// (Optional) The list of build aliases for the title.
        /// </summary>
        public PFMultiplayerServerBuildAliasDetailsResponse[]? BuildAliases;

        /// <summary>
        /// The page size on the response.
        /// </summary>
        public int PageSize;

        /// <summary>
        /// (Optional) The skip token for the paged response.
        /// </summary>
        public string? SkipToken;

        internal unsafe PFMultiplayerServerListBuildAliasesResponse(Interop.PFMultiplayerServerListBuildAliasesResponse interop)
        {

            BuildAliases = (interop.buildAliases == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.buildAliases, interop.buildAliasesCount, elem => new PFMultiplayerServerBuildAliasDetailsResponse(elem));

            PageSize = interop.pageSize;

            SkipToken = (interop.skipToken == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.skipToken);

        }
    }

    /// <summary>
    /// PFMultiplayerServerListBuildSummariesRequest data model. Returns a list of summarized details of
    /// all multiplayer server builds for a title.
    /// </summary>
    public struct PFMultiplayerServerListBuildSummariesRequest
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

        internal unsafe static void ToInterop(PFMultiplayerServerListBuildSummariesRequest self, Interop.PFMultiplayerServerListBuildSummariesRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.PageSize != null)
            {
                interop->pageSize = (int*)buffer.AddBuffer(sizeof(int));
                *interop->pageSize = self.PageSize.Value;
            }

            if (self.SkipToken != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.SkipToken, &interop->skipToken, buffer);
            }

        }
    }

    /// <summary>
    /// PFMultiplayerServerCurrentServerStats data model.
    /// </summary>
    public struct PFMultiplayerServerCurrentServerStats
    {
        /// <summary>
        /// The number of active multiplayer servers.
        /// </summary>
        public int Active;

        /// <summary>
        /// The number of multiplayer servers still downloading game resources (such as assets).
        /// </summary>
        public int Propping;

        /// <summary>
        /// The number of standingby multiplayer servers.
        /// </summary>
        public int StandingBy;

        /// <summary>
        /// The total number of multiplayer servers.
        /// </summary>
        public int Total;

        internal unsafe PFMultiplayerServerCurrentServerStats(Interop.PFMultiplayerServerCurrentServerStats interop)
        {

            Active = interop.active;

            Propping = interop.propping;

            StandingBy = interop.standingBy;

            Total = interop.total;

        }

        internal unsafe static void ToInterop(PFMultiplayerServerCurrentServerStats self, Interop.PFMultiplayerServerCurrentServerStats* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->active = self.Active;

            interop->propping = self.Propping;

            interop->standingBy = self.StandingBy;

            interop->total = self.Total;

        }
    }

    /// <summary>
    /// PFMultiplayerServerDynamicStandbyThreshold data model.
    /// </summary>
    public struct PFMultiplayerServerDynamicStandbyThreshold
    {
        /// <summary>
        /// When the trigger threshold is reached, multiply by this value.
        /// </summary>
        public double Multiplier;

        /// <summary>
        /// The multiplier will be applied when the actual standby divided by target standby floor is less than
        /// this value.
        /// </summary>
        public double TriggerThresholdPercentage;

        internal unsafe PFMultiplayerServerDynamicStandbyThreshold(Interop.PFMultiplayerServerDynamicStandbyThreshold interop)
        {

            Multiplier = interop.multiplier;

            TriggerThresholdPercentage = interop.triggerThresholdPercentage;

        }

        internal unsafe static void ToInterop(PFMultiplayerServerDynamicStandbyThreshold self, Interop.PFMultiplayerServerDynamicStandbyThreshold* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->multiplier = self.Multiplier;

            interop->triggerThresholdPercentage = self.TriggerThresholdPercentage;

        }
    }

    /// <summary>
    /// PFMultiplayerServerDynamicStandbySettings data model.
    /// </summary>
    public struct PFMultiplayerServerDynamicStandbySettings
    {
        /// <summary>
        /// (Optional) List of auto standing by trigger values and corresponding standing by multiplier. Defaults
        /// to 1.5X at 50%, 3X at 25%, and 4X at 5%.
        /// </summary>
        public PFMultiplayerServerDynamicStandbyThreshold[]? DynamicFloorMultiplierThresholds;

        /// <summary>
        /// When true, dynamic standby will be enabled.
        /// </summary>
        public bool IsEnabled;

        /// <summary>
        /// (Optional) The time it takes to reduce target standing by to configured floor value after an increase.
        /// Defaults to 30 minutes.
        /// </summary>
        public int? RampDownSeconds;

        internal unsafe PFMultiplayerServerDynamicStandbySettings(Interop.PFMultiplayerServerDynamicStandbySettings interop)
        {

            DynamicFloorMultiplierThresholds = (interop.dynamicFloorMultiplierThresholds == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.dynamicFloorMultiplierThresholds, interop.dynamicFloorMultiplierThresholdsCount, elem => new PFMultiplayerServerDynamicStandbyThreshold(elem));

            IsEnabled = InteropWrapper.WrapperHelpers.InteropToBool(interop.isEnabled);

            RampDownSeconds = (interop.rampDownSeconds == null) ? null : *interop.rampDownSeconds;

        }

        internal unsafe static void ToInterop(PFMultiplayerServerDynamicStandbySettings self, Interop.PFMultiplayerServerDynamicStandbySettings* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.DynamicFloorMultiplierThresholds != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.DynamicFloorMultiplierThresholds, &interop->dynamicFloorMultiplierThresholds, buffer, PFMultiplayerServerDynamicStandbyThreshold.ToInterop);
                interop->dynamicFloorMultiplierThresholdsCount = (uint)self.DynamicFloorMultiplierThresholds.Length;
            }

            interop->isEnabled = InteropWrapper.WrapperHelpers.BoolToInterop(self.IsEnabled);

            if (self.RampDownSeconds != null)
            {
                interop->rampDownSeconds = (int*)buffer.AddBuffer(sizeof(int));
                *interop->rampDownSeconds = self.RampDownSeconds.Value;
            }

        }
    }

    /// <summary>
    /// PFMultiplayerServerSchedule data model.
    /// </summary>
    public struct PFMultiplayerServerSchedule
    {
        /// <summary>
        /// (Optional) A short description about this schedule. For example, "Game launch on July 15th".
        /// </summary>
        public string? Description;

        /// <summary>
        /// The date and time in UTC at which the schedule ends. If IsRecurringWeekly is true, this schedule
        /// will keep renewing for future weeks until disabled or removed.
        /// </summary>
        public long EndTime;

        /// <summary>
        /// Disables the schedule.
        /// </summary>
        public bool IsDisabled;

        /// <summary>
        /// If true, the StartTime and EndTime will get renewed every week.
        /// </summary>
        public bool IsRecurringWeekly;

        /// <summary>
        /// The date and time in UTC at which the schedule starts.
        /// </summary>
        public long StartTime;

        /// <summary>
        /// The standby target to maintain for the duration of the schedule.
        /// </summary>
        public int TargetStandby;

        internal unsafe PFMultiplayerServerSchedule(Interop.PFMultiplayerServerSchedule interop)
        {

            Description = (interop.description == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.description);

            EndTime = interop.endTime;

            IsDisabled = InteropWrapper.WrapperHelpers.InteropToBool(interop.isDisabled);

            IsRecurringWeekly = InteropWrapper.WrapperHelpers.InteropToBool(interop.isRecurringWeekly);

            StartTime = interop.startTime;

            TargetStandby = interop.targetStandby;

        }

        internal unsafe static void ToInterop(PFMultiplayerServerSchedule self, Interop.PFMultiplayerServerSchedule* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Description != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Description, &interop->description, buffer);
            }

            interop->endTime = self.EndTime;

            interop->isDisabled = InteropWrapper.WrapperHelpers.BoolToInterop(self.IsDisabled);

            interop->isRecurringWeekly = InteropWrapper.WrapperHelpers.BoolToInterop(self.IsRecurringWeekly);

            interop->startTime = self.StartTime;

            interop->targetStandby = self.TargetStandby;

        }
    }

    /// <summary>
    /// PFMultiplayerServerScheduledStandbySettings data model.
    /// </summary>
    public struct PFMultiplayerServerScheduledStandbySettings
    {
        /// <summary>
        /// When true, scheduled standby will be enabled.
        /// </summary>
        public bool IsEnabled;

        /// <summary>
        /// (Optional) A list of non-overlapping schedules.
        /// </summary>
        public PFMultiplayerServerSchedule[]? ScheduleList;

        internal unsafe PFMultiplayerServerScheduledStandbySettings(Interop.PFMultiplayerServerScheduledStandbySettings interop)
        {

            IsEnabled = InteropWrapper.WrapperHelpers.InteropToBool(interop.isEnabled);

            ScheduleList = (interop.scheduleList == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.scheduleList, interop.scheduleListCount, elem => new PFMultiplayerServerSchedule(elem));

        }

        internal unsafe static void ToInterop(PFMultiplayerServerScheduledStandbySettings self, Interop.PFMultiplayerServerScheduledStandbySettings* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->isEnabled = InteropWrapper.WrapperHelpers.BoolToInterop(self.IsEnabled);

            if (self.ScheduleList != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.ScheduleList, &interop->scheduleList, buffer, PFMultiplayerServerSchedule.ToInterop);
                interop->scheduleListCount = (uint)self.ScheduleList.Length;
            }

        }
    }

    /// <summary>
    /// PFMultiplayerServerBuildRegion data model.
    /// </summary>
    public struct PFMultiplayerServerBuildRegion
    {
        /// <summary>
        /// (Optional) The current multiplayer server stats for the region.
        /// </summary>
        public PFMultiplayerServerCurrentServerStats? CurrentServerStats;

        /// <summary>
        /// (Optional) Optional settings to control dynamic adjustment of standby target.
        /// </summary>
        public PFMultiplayerServerDynamicStandbySettings? DynamicStandbySettings;

        /// <summary>
        /// Whether the game assets provided for the build have been replicated to this region.
        /// </summary>
        public bool IsAssetReplicationComplete;

        /// <summary>
        /// The maximum number of multiplayer servers for the region.
        /// </summary>
        public int MaxServers;

        /// <summary>
        /// (Optional) Regional override for the number of multiplayer servers to host on a single VM of the
        /// build.
        /// </summary>
        public int? MultiplayerServerCountPerVm;

        /// <summary>
        /// (Optional) The build region.
        /// </summary>
        public string? Region;

        /// <summary>
        /// (Optional) Optional settings to set the standby target to specified values during the supplied schedules.
        /// </summary>
        public PFMultiplayerServerScheduledStandbySettings? ScheduledStandbySettings;

        /// <summary>
        /// The target number of standby multiplayer servers for the region.
        /// </summary>
        public int StandbyServers;

        /// <summary>
        /// (Optional) The status of multiplayer servers in the build region. Valid values are - Unknown, Initialized,
        /// Deploying, Deployed, Unhealthy, Deleting, Deleted.
        /// </summary>
        public string? Status;

        /// <summary>
        /// (Optional) Regional override for the VM size the build was created on.
        /// </summary>
        public PFMultiplayerServerAzureVmSize? VmSize;

        internal unsafe PFMultiplayerServerBuildRegion(Interop.PFMultiplayerServerBuildRegion interop)
        {

            CurrentServerStats = (interop.currentServerStats == null) ? null : new(*interop.currentServerStats);

            DynamicStandbySettings = (interop.dynamicStandbySettings == null) ? null : new(*interop.dynamicStandbySettings);

            IsAssetReplicationComplete = InteropWrapper.WrapperHelpers.InteropToBool(interop.isAssetReplicationComplete);

            MaxServers = interop.maxServers;

            MultiplayerServerCountPerVm = (interop.multiplayerServerCountPerVm == null) ? null : *interop.multiplayerServerCountPerVm;

            Region = (interop.region == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.region);

            ScheduledStandbySettings = (interop.scheduledStandbySettings == null) ? null : new(*interop.scheduledStandbySettings);

            StandbyServers = interop.standbyServers;

            Status = (interop.status == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.status);

            VmSize = (interop.vmSize == null) ? null : (PFMultiplayerServerAzureVmSize?)(*interop.vmSize);

        }

        internal unsafe static void ToInterop(PFMultiplayerServerBuildRegion self, Interop.PFMultiplayerServerBuildRegion* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CurrentServerStats != null)
            {
                interop->currentServerStats = (Interop.PFMultiplayerServerCurrentServerStats*)buffer.AddBuffer(sizeof(Interop.PFMultiplayerServerCurrentServerStats));
                PFMultiplayerServerCurrentServerStats.ToInterop(self.CurrentServerStats.Value, interop->currentServerStats, buffer);
            }

            if (self.DynamicStandbySettings != null)
            {
                interop->dynamicStandbySettings = (Interop.PFMultiplayerServerDynamicStandbySettings*)buffer.AddBuffer(sizeof(Interop.PFMultiplayerServerDynamicStandbySettings));
                PFMultiplayerServerDynamicStandbySettings.ToInterop(self.DynamicStandbySettings.Value, interop->dynamicStandbySettings, buffer);
            }

            interop->isAssetReplicationComplete = InteropWrapper.WrapperHelpers.BoolToInterop(self.IsAssetReplicationComplete);

            interop->maxServers = self.MaxServers;

            if (self.MultiplayerServerCountPerVm != null)
            {
                interop->multiplayerServerCountPerVm = (int*)buffer.AddBuffer(sizeof(int));
                *interop->multiplayerServerCountPerVm = self.MultiplayerServerCountPerVm.Value;
            }

            if (self.Region != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Region, &interop->region, buffer);
            }

            if (self.ScheduledStandbySettings != null)
            {
                interop->scheduledStandbySettings = (Interop.PFMultiplayerServerScheduledStandbySettings*)buffer.AddBuffer(sizeof(Interop.PFMultiplayerServerScheduledStandbySettings));
                PFMultiplayerServerScheduledStandbySettings.ToInterop(self.ScheduledStandbySettings.Value, interop->scheduledStandbySettings, buffer);
            }

            interop->standbyServers = self.StandbyServers;

            if (self.Status != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Status, &interop->status, buffer);
            }

            if (self.VmSize != null)
            {
                interop->vmSize = (Interop.PFMultiplayerServerAzureVmSize*)buffer.AddBuffer(sizeof(Interop.PFMultiplayerServerAzureVmSize));
                *interop->vmSize = (Interop.PFMultiplayerServerAzureVmSize)self.VmSize.Value;
            }

        }
    }

    /// <summary>
    /// PFMultiplayerServerBuildSummary data model.
    /// </summary>
    public struct PFMultiplayerServerBuildSummary
    {
        /// <summary>
        /// (Optional) The guid string build ID of the build.
        /// </summary>
        public string? BuildId;

        /// <summary>
        /// (Optional) The build name.
        /// </summary>
        public string? BuildName;

        /// <summary>
        /// (Optional) The time the build was created in UTC.
        /// </summary>
        public long? CreationTime;

        /// <summary>
        /// (Optional) The metadata of the build.
        /// </summary>
        public Dictionary<string, string>? Metadata;

        /// <summary>
        /// (Optional) The configuration and status for each region in the build.
        /// </summary>
        public PFMultiplayerServerBuildRegion[]? RegionConfigurations;

        internal unsafe PFMultiplayerServerBuildSummary(Interop.PFMultiplayerServerBuildSummary interop)
        {

            BuildId = (interop.buildId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.buildId);

            BuildName = (interop.buildName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.buildName);

            CreationTime = (interop.creationTime == null) ? null : *interop.creationTime;

            Metadata = (interop.metadata == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.metadata, interop.metadataCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), InteropWrapper.WrapperHelpers.InteropToString(pair.value)));

            RegionConfigurations = (interop.regionConfigurations == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.regionConfigurations, interop.regionConfigurationsCount, elem => new PFMultiplayerServerBuildRegion(elem));

        }

        internal unsafe static void ToInterop(PFMultiplayerServerBuildSummary self, Interop.PFMultiplayerServerBuildSummary* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.BuildId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.BuildId, &interop->buildId, buffer);
            }

            if (self.BuildName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.BuildName, &interop->buildName, buffer);
            }

            if (self.CreationTime != null)
            {
                interop->creationTime = (long*)buffer.AddBuffer(sizeof(long));
                *interop->creationTime = self.CreationTime.Value;
            }

            if (self.Metadata != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.Metadata, &interop->metadata, buffer);
                interop->metadataCount = (uint)self.Metadata.Count;
            }

            if (self.RegionConfigurations != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.RegionConfigurations, &interop->regionConfigurations, buffer, PFMultiplayerServerBuildRegion.ToInterop);
                interop->regionConfigurationsCount = (uint)self.RegionConfigurations.Length;
            }

        }
    }

    /// <summary>
    /// PFMultiplayerServerListBuildSummariesResponse data model.
    /// </summary>
    public struct PFMultiplayerServerListBuildSummariesResponse
    {
        /// <summary>
        /// (Optional) The list of build summaries for a title.
        /// </summary>
        public PFMultiplayerServerBuildSummary[]? BuildSummaries;

        /// <summary>
        /// The page size on the response.
        /// </summary>
        public int PageSize;

        /// <summary>
        /// (Optional) The skip token for the paged response.
        /// </summary>
        public string? SkipToken;

        internal unsafe PFMultiplayerServerListBuildSummariesResponse(Interop.PFMultiplayerServerListBuildSummariesResponse interop)
        {

            BuildSummaries = (interop.buildSummaries == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.buildSummaries, interop.buildSummariesCount, elem => new PFMultiplayerServerBuildSummary(elem));

            PageSize = interop.pageSize;

            SkipToken = (interop.skipToken == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.skipToken);

        }
    }

    /// <summary>
    /// PFMultiplayerServerListQosServersForTitleRequest data model. Returns a list of quality of service
    /// servers for a title.
    /// </summary>
    public struct PFMultiplayerServerListQosServersForTitleRequest
    {
        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Indicates that the response should contain Qos servers for all regions, including those
        /// where there are no builds deployed for the title.
        /// </summary>
        public bool? IncludeAllRegions;

        /// <summary>
        /// (Optional) Indicates the Routing Preference used by the Qos servers. The default Routing Preference
        /// is Microsoft.
        /// </summary>
        public string? RoutingPreference;

        internal unsafe static void ToInterop(PFMultiplayerServerListQosServersForTitleRequest self, Interop.PFMultiplayerServerListQosServersForTitleRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.IncludeAllRegions != null)
            {
                interop->includeAllRegions = (byte*)buffer.AddBuffer(sizeof(byte));
                *interop->includeAllRegions = InteropWrapper.WrapperHelpers.BoolToInterop(self.IncludeAllRegions.Value);
            }

            if (self.RoutingPreference != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.RoutingPreference, &interop->routingPreference, buffer);
            }

        }
    }

    /// <summary>
    /// PFMultiplayerServerQosServer data model.
    /// </summary>
    public struct PFMultiplayerServerQosServer
    {
        /// <summary>
        /// (Optional) The region the QoS server is located in.
        /// </summary>
        public string? Region;

        /// <summary>
        /// (Optional) The QoS server URL.
        /// </summary>
        public string? ServerUrl;

        internal unsafe PFMultiplayerServerQosServer(Interop.PFMultiplayerServerQosServer interop)
        {

            Region = (interop.region == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.region);

            ServerUrl = (interop.serverUrl == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.serverUrl);

        }

        internal unsafe static void ToInterop(PFMultiplayerServerQosServer self, Interop.PFMultiplayerServerQosServer* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Region != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Region, &interop->region, buffer);
            }

            if (self.ServerUrl != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ServerUrl, &interop->serverUrl, buffer);
            }

        }
    }

    /// <summary>
    /// PFMultiplayerServerListQosServersForTitleResponse data model.
    /// </summary>
    public struct PFMultiplayerServerListQosServersForTitleResponse
    {
        /// <summary>
        /// The page size on the response.
        /// </summary>
        public int PageSize;

        /// <summary>
        /// (Optional) The list of QoS servers.
        /// </summary>
        public PFMultiplayerServerQosServer[]? QosServers;

        /// <summary>
        /// (Optional) The skip token for the paged response.
        /// </summary>
        public string? SkipToken;

        internal unsafe PFMultiplayerServerListQosServersForTitleResponse(Interop.PFMultiplayerServerListQosServersForTitleResponse interop)
        {

            PageSize = interop.pageSize;

            QosServers = (interop.qosServers == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.qosServers, interop.qosServersCount, elem => new PFMultiplayerServerQosServer(elem));

            SkipToken = (interop.skipToken == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.skipToken);

        }
    }

    /// <summary>
    /// PFMultiplayerServerBuildAliasParams data model.
    /// </summary>
    public struct PFMultiplayerServerBuildAliasParams
    {
        /// <summary>
        /// The guid string alias ID to use for the request.
        /// </summary>
        public string AliasId;

        internal unsafe PFMultiplayerServerBuildAliasParams(Interop.PFMultiplayerServerBuildAliasParams interop)
        {

            AliasId = InteropWrapper.WrapperHelpers.InteropToString(interop.aliasId)!;

        }

        internal unsafe static void ToInterop(PFMultiplayerServerBuildAliasParams self, Interop.PFMultiplayerServerBuildAliasParams* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.AliasId, &interop->aliasId, buffer);

        }
    }

    /// <summary>
    /// PFMultiplayerServerRequestMultiplayerServerRequest data model. Requests a multiplayer server session
    /// from a particular build in any of the given preferred regions.
    /// </summary>
    public struct PFMultiplayerServerRequestMultiplayerServerRequest
    {
        /// <summary>
        /// (Optional) The identifiers of the build alias to use for the request.
        /// </summary>
        public PFMultiplayerServerBuildAliasParams? BuildAliasParams;

        /// <summary>
        /// (Optional) The guid string build ID of the multiplayer server to request.
        /// </summary>
        public string? BuildId;

        /// <summary>
        /// (Optional) The optional custom tags associated with the request (e.g. build number, external trace
        /// identifiers, etc.).
        /// </summary>
        public Dictionary<string, string>? CustomTags;

        /// <summary>
        /// (Optional) Initial list of players (potentially matchmade) allowed to connect to the game. This list
        /// is passed to the game server when requested (via GSDK) and can be used to validate players connecting
        /// to it.
        /// </summary>
        public string[]? InitialPlayers;

        /// <summary>
        /// The preferred regions to request a multiplayer server from. The Multiplayer Service will iterate
        /// through the regions in the specified order and allocate a server from the first one that has servers
        /// available.
        /// </summary>
        public string[] PreferredRegions;

        /// <summary>
        /// (Optional) Data encoded as a string that is passed to the game server when requested. This can be
        /// used to communicate information such as game mode or map through the request flow. Maximum size is
        /// 8KB.
        /// </summary>
        public string? SessionCookie;

        /// <summary>
        /// A guid string session ID created track the multiplayer server session over its life.
        /// </summary>
        public string SessionId;

        internal unsafe static void ToInterop(PFMultiplayerServerRequestMultiplayerServerRequest self, Interop.PFMultiplayerServerRequestMultiplayerServerRequest* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.BuildAliasParams != null)
            {
                interop->buildAliasParams = (Interop.PFMultiplayerServerBuildAliasParams*)buffer.AddBuffer(sizeof(Interop.PFMultiplayerServerBuildAliasParams));
                PFMultiplayerServerBuildAliasParams.ToInterop(self.BuildAliasParams.Value, interop->buildAliasParams, buffer);
            }

            if (self.BuildId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.BuildId, &interop->buildId, buffer);
            }

            if (self.CustomTags != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomTags, &interop->customTags, buffer);
                interop->customTagsCount = (uint)self.CustomTags.Count;
            }

            if (self.InitialPlayers != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.InitialPlayers, &interop->initialPlayers, buffer);
                interop->initialPlayersCount = (uint)self.InitialPlayers.Length;
            }

            InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.PreferredRegions, &interop->preferredRegions, buffer);
            interop->preferredRegionsCount = (uint)self.PreferredRegions.Length;

            if (self.SessionCookie != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.SessionCookie, &interop->sessionCookie, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.SessionId, &interop->sessionId, buffer);

        }
    }

    /// <summary>
    /// PFMultiplayerServerConnectedPlayer data model.
    /// </summary>
    public struct PFMultiplayerServerConnectedPlayer
    {
        /// <summary>
        /// (Optional) The player ID of the player connected to the multiplayer server.
        /// </summary>
        public string? PlayerId;

        internal unsafe PFMultiplayerServerConnectedPlayer(Interop.PFMultiplayerServerConnectedPlayer interop)
        {

            PlayerId = (interop.playerId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playerId);

        }

        internal unsafe static void ToInterop(PFMultiplayerServerConnectedPlayer self, Interop.PFMultiplayerServerConnectedPlayer* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.PlayerId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayerId, &interop->playerId, buffer);
            }

        }
    }

    /// <summary>
    /// PFMultiplayerServerPort data model.
    /// </summary>
    public struct PFMultiplayerServerPort
    {
        /// <summary>
        /// The name for the port.
        /// </summary>
        public string Name;

        /// <summary>
        /// The number for the port.
        /// </summary>
        public int Num;

        /// <summary>
        /// The protocol for the port.
        /// </summary>
        public PFMultiplayerServerProtocolType Protocol;

        internal unsafe PFMultiplayerServerPort(Interop.PFMultiplayerServerPort interop)
        {

            Name = InteropWrapper.WrapperHelpers.InteropToString(interop.name)!;

            Num = interop.num;

            Protocol = (PFMultiplayerServerProtocolType)(interop.protocol);

        }

        internal unsafe static void ToInterop(PFMultiplayerServerPort self, Interop.PFMultiplayerServerPort* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

            interop->num = self.Num;

            interop->protocol = (Interop.PFMultiplayerServerProtocolType)self.Protocol;

        }
    }

    /// <summary>
    /// PFMultiplayerServerPublicIpAddress data model.
    /// </summary>
    public struct PFMultiplayerServerPublicIpAddress
    {
        /// <summary>
        /// FQDN of the public IP.
        /// </summary>
        public string FQDN;

        /// <summary>
        /// Server IP Address.
        /// </summary>
        public string IpAddress;

        /// <summary>
        /// Routing Type of the public IP.
        /// </summary>
        public string RoutingType;

        internal unsafe PFMultiplayerServerPublicIpAddress(Interop.PFMultiplayerServerPublicIpAddress interop)
        {

            FQDN = InteropWrapper.WrapperHelpers.InteropToString(interop.fQDN)!;

            IpAddress = InteropWrapper.WrapperHelpers.InteropToString(interop.ipAddress)!;

            RoutingType = InteropWrapper.WrapperHelpers.InteropToString(interop.routingType)!;

        }

        internal unsafe static void ToInterop(PFMultiplayerServerPublicIpAddress self, Interop.PFMultiplayerServerPublicIpAddress* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.FQDN, &interop->fQDN, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.IpAddress, &interop->ipAddress, buffer);

            InteropWrapper.WrapperHelpers.StringToInterop(self.RoutingType, &interop->routingType, buffer);

        }
    }

    /// <summary>
    /// PFMultiplayerServerRequestMultiplayerServerResponse data model.
    /// </summary>
    public struct PFMultiplayerServerRequestMultiplayerServerResponse
    {
        /// <summary>
        /// (Optional) The identity of the build in which the server was allocated.
        /// </summary>
        public string? BuildId;

        /// <summary>
        /// (Optional) The connected players in the multiplayer server.
        /// </summary>
        public PFMultiplayerServerConnectedPlayer[]? ConnectedPlayers;

        /// <summary>
        /// (Optional) The fully qualified domain name of the virtual machine that is hosting this multiplayer
        /// server.
        /// </summary>
        public string? FQDN;

        /// <summary>
        /// (Optional) The public IPv4 address of the virtual machine that is hosting this multiplayer server.
        /// </summary>
        public string? IPV4Address;

        /// <summary>
        /// (Optional) The time (UTC) at which a change in the multiplayer server state was observed.
        /// </summary>
        public long? LastStateTransitionTime;

        /// <summary>
        /// (Optional) The ports the multiplayer server uses.
        /// </summary>
        public PFMultiplayerServerPort[]? Ports;

        /// <summary>
        /// (Optional) The list of public Ipv4 addresses associated with the server.
        /// </summary>
        public PFMultiplayerServerPublicIpAddress[]? PublicIPV4Addresses;

        /// <summary>
        /// (Optional) The region the multiplayer server is located in.
        /// </summary>
        public string? Region;

        /// <summary>
        /// (Optional) The string server ID of the multiplayer server generated by PlayFab.
        /// </summary>
        public string? ServerId;

        /// <summary>
        /// (Optional) The guid string session ID of the multiplayer server.
        /// </summary>
        public string? SessionId;

        /// <summary>
        /// (Optional) The state of the multiplayer server.
        /// </summary>
        public string? State;

        /// <summary>
        /// (Optional) The virtual machine ID that the multiplayer server is located on.
        /// </summary>
        public string? VmId;

        internal unsafe PFMultiplayerServerRequestMultiplayerServerResponse(Interop.PFMultiplayerServerRequestMultiplayerServerResponse interop)
        {

            BuildId = (interop.buildId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.buildId);

            ConnectedPlayers = (interop.connectedPlayers == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.connectedPlayers, interop.connectedPlayersCount, elem => new PFMultiplayerServerConnectedPlayer(elem));

            FQDN = (interop.fQDN == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.fQDN);

            IPV4Address = (interop.iPV4Address == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.iPV4Address);

            LastStateTransitionTime = (interop.lastStateTransitionTime == null) ? null : *interop.lastStateTransitionTime;

            Ports = (interop.ports == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.ports, interop.portsCount, elem => new PFMultiplayerServerPort(elem));

            PublicIPV4Addresses = (interop.publicIPV4Addresses == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.publicIPV4Addresses, interop.publicIPV4AddressesCount, elem => new PFMultiplayerServerPublicIpAddress(elem));

            Region = (interop.region == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.region);

            ServerId = (interop.serverId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.serverId);

            SessionId = (interop.sessionId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.sessionId);

            State = (interop.state == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.state);

            VmId = (interop.vmId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.vmId);

        }
    }

}
