// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// OperationTypes enum.
    /// </summary>
    public enum PFOperationTypes : uint
    {
        Created = Interop.PFOperationTypes.Created,
        Updated = Interop.PFOperationTypes.Updated,
        Deleted = Interop.PFOperationTypes.Deleted,
        None = Interop.PFOperationTypes.None
    }

    /// <summary>
    /// EventType enum.
    /// </summary>
    public enum PFEventType : uint
    {
        None = Interop.PFEventType.None,
        Telemetry = Interop.PFEventType.Telemetry,
        PlayStream = Interop.PFEventType.PlayStream
    }

    /// <summary>
    /// ResetInterval enum.
    /// </summary>
    public enum PFResetInterval : uint
    {
        Manual = Interop.PFResetInterval.Manual,
        Hour = Interop.PFResetInterval.Hour,
        Day = Interop.PFResetInterval.Day,
        Week = Interop.PFResetInterval.Week,
        Month = Interop.PFResetInterval.Month
    }

    /// <summary>
    /// PFVersionConfiguration data model.
    /// </summary>
    public struct PFVersionConfiguration
    {
        /// <summary>
        /// The maximum number of versions of this leaderboard/statistic that can be queried. .
        /// </summary>
        public int MaxQueryableVersions;

        /// <summary>
        /// Reset interval that statistics or leaderboards will reset on. When using Manual intervalthe reset
        /// can only be increased by calling the Increase version API. When using Hour interval the resetwill
        /// occur at the start of the next hour UTC time. When using Day interval the reset will occur at thestart
        /// of the next day in UTC time. When using the Week interval the reset will occur at the start ofthe
        /// next Monday in UTC time. When using Month interval the reset will occur at the start of the nextmonth
        /// in UTC time.
        /// </summary>
        public PFResetInterval ResetInterval;

        internal unsafe PFVersionConfiguration(Interop.PFVersionConfiguration interop)
        {

            MaxQueryableVersions = interop.maxQueryableVersions;

            ResetInterval = (PFResetInterval)(interop.resetInterval);

        }

        internal unsafe static void ToInterop(PFVersionConfiguration self, Interop.PFVersionConfiguration* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->maxQueryableVersions = self.MaxQueryableVersions;

            interop->resetInterval = (Interop.PFResetInterval)self.ResetInterval;

        }
    }

}
