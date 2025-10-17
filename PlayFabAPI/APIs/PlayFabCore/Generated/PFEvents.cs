// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

namespace PlayFab
{
    public partial class PFEntity
    {
        /// <summary>
        /// Write batches of entity based events to PlayStream. The namespace of the Event must be 'custom' or
        /// start with 'custom.'.
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFEventsWriteEventsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// When the asynchronous task is complete, call <see cref="PFEventsWriteEventsGetResultSize"/> and <see
        /// cref="PFEventsWriteEventsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFEventsWriteEventsResponse>> EventsWriteEventsAsync(
            PFEventsWriteEventsRequest request
        )
        {
            return await InteropWrapper.Core.PFEvents.PFEventsWriteEventsAsync(InteropHandle, request);
        }

        /// <summary>
        /// Write batches of entity based events to as Telemetry events (bypass PlayStream). The namespace must
        /// be 'custom' or start with 'custom.'
        /// </summary>
        /// <param name="request">Populated request object.</param>
        /// <returns>A task which will provide the result code for this API operation and a PFEventsWriteEventsResponse.</returns>
        /// <remarks>
        /// This API is available on all platforms.
        /// This API must be called with either X-EntityToken or X-TelemetryKey headers. If sending X-EntityToken
        /// the value must be a valid EntityToken for your title. If using X-TelemetryKey the value must be a
        /// Telemetry Key configured for your title set to 'Active'. If both are provided, X-TelemetryKey will
        /// be ignored.
        ///
        /// When the asynchronous task is complete, call <see cref="PFEventsWriteTelemetryEventsGetResultSize"/>
        /// and <see cref="PFEventsWriteTelemetryEventsGetResult"/> to get the result.
        /// </remarks>
        public async Task<PFResult<PFEventsWriteEventsResponse>> EventsWriteTelemetryEventsAsync(
            PFEventsWriteEventsRequest request
        )
        {
            return await InteropWrapper.Core.PFEvents.PFEventsWriteTelemetryEventsAsync(InteropHandle, request);
        }
    }
}
