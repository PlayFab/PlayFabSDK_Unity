// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;

namespace PlayFab
{
    public partial class PFServiceConfig
    {
        /// <summary>
        /// Creates an event pipeline to upload Telemetry events using a Telemetry Key.
        /// </summary>
        /// <param name="telemetryKey">The key to use if telemetry key logging will be used.</param>
        /// <param name="queue">The async queue where background work will be scheduled and where event callbacks will be invoked.</param>
        /// <param name="eventPipelineBatchUploadedEventHandler">Optional handler that will be invoked when a batch of events is uploaded.</param>
        /// <param name="eventPipelineBatchFailedEventHandler">Optional handler that will be invoked when uploading a batch of events fails.</param>
        /// <param name="handlerContext">Optional pointer to data used by the event handlers.</param>
        /// <returns>Result code for this API operation.  Possible values are S_OK, E_INVALIDARG, E_PF_NOT_INITIALIZED or E_FAIL.</returns>
        public PFResult<PFEventPipeline> CreateTelemetryPipelineWithKey(
            string telemetryKey,
            PFEventPipelineBatchUploadSucceededEventHandler eventPipelineBatchUploadedEventHandler,
            PFEventPipelineBatchUploadFailedEventHandler eventPipelineBatchFailedEventHandler,
            object handlerContext)
        {
            PFEventPipelineTelemetryKeyConfig config = new()
            {
                TelemetryKey = telemetryKey,
                ServiceConfigHandle = InteropHandle
            };
            var result = InteropWrapper.Core.PFEventPipeline.PFEventPipelineCreateTelemetryPipelineHandleWithKey(
                                                                config,
                                                                eventPipelineBatchUploadedEventHandler,
                                                                eventPipelineBatchFailedEventHandler,
                                                                handlerContext);

            return result.Failed() ? new(result.HResult)
                                   : new(new(result.Result), result.HResult);
        }
    }

    public partial class PFEntity
    {
        /// <summary>
        /// Creates an event pipeline to upload Telemetry events using an Entity.
        /// </summary>
        /// <param name="eventPipelineBatchUploadedEventHandler">Optional handler that will be invoked when a batch of events is uploaded.</param>
        /// <param name="eventPipelineBatchFailedEventHandler">Optional handler that will be invoked when uploading a batch of events fails.</param>
        /// <param name="handlerContext">Optional pointer to data used by the event handlers.</param>
        /// <returns>Result code for this API operation.  Possible values are S_OK, E_INVALIDARG, E_PF_NOT_INITIALIZED or E_FAIL.</returns>
        public PFResult<PFEventPipeline> CreateTelemetryPipelineWithEntity(
            PFEventPipelineBatchUploadSucceededEventHandler eventPipelineBatchUploadedEventHandler,
            PFEventPipelineBatchUploadFailedEventHandler eventPipelineBatchFailedEventHandler,
            object handlerContext)
        {
            var result = InteropWrapper.Core.PFEventPipeline.PFEventPipelineCreateTelemetryPipelineHandleWithEntity(
                                                                InteropHandle,
                                                                eventPipelineBatchUploadedEventHandler,
                                                                eventPipelineBatchFailedEventHandler,
                                                                handlerContext);

            return result.Failed() ? new(result.HResult)
                                   : new(new(result.Result), result.HResult);
        }

        /// <summary>
        /// Creates an event pipeline to upload PlayStream events using an Entity.
        /// </summary>
        /// <param name="eventPipelineBatchUploadedEventHandler">Optional handler that will be invoked when a batch of events is uploaded.</param>
        /// <param name="eventPipelineBatchFailedEventHandler">Optional handler that will be invoked when uploading a batch of events fails.</param>
        /// <param name="handlerContext">Optional pointer to data used by the event handlers.</param>
        /// <returns>Result code for this API operation.  Possible values are S_OK, E_INVALIDARG, E_PF_NOT_INITIALIZED or E_FAIL.</returns>
        public PFResult<PFEventPipeline> CreatePlayStreamPipeline(
            PFEventPipelineBatchUploadSucceededEventHandler eventPipelineBatchUploadedEventHandler,
            PFEventPipelineBatchUploadFailedEventHandler eventPipelineBatchFailedEventHandler,
            object handlerContext)
        {
            var result = InteropWrapper.Core.PFEventPipeline.PFEventPipelineCreatePlayStreamPipelineHandle(
                                                                InteropHandle,
                                                                eventPipelineBatchUploadedEventHandler,
                                                                eventPipelineBatchFailedEventHandler,
                                                                handlerContext);

            return result.Failed() ? new(result.HResult)
                                   : new(new(result.Result), result.HResult);
        }
    }

    internal class PFEventPipelineSafeHandle : SafeHandle
    {
        public override bool IsInvalid => handle == IntPtr.Zero;

        public PFEventPipelineSafeHandle(PFEventPipelineHandle EventPipelineHandle) : base(IntPtr.Zero, true)
        {
            SetHandle(EventPipelineHandle.Handle);
        }

        protected override bool ReleaseHandle()
        {
            InteropWrapper.Core.PFEventPipeline.PFEventPipelineCloseHandle(new(handle));
            return true;
        }
    }

    public partial class PFEventPipeline : IDisposable
    {
        internal PFEventPipelineSafeHandle EventPipelineHandle { get; set; }

        protected PFEventPipelineHandle InteropHandle { get; }

        public PFEventPipeline(PFEventPipelineHandle handle)
        {
            EventPipelineHandle = new(handle);
            InteropHandle = handle;
        }

        ~PFEventPipeline()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                EventPipelineHandle?.Dispose();
                EventPipelineHandle = null;
            }
        }

        public PFResult<PFEventPipeline> Duplicate()
        {
            var result = InteropWrapper.Core.PFEventPipeline.PFEventPipelineDuplicateHandle(InteropHandle);
            return result.Failed() ? new(result.HResult)
                                   : new(new(result.Result), result.HResult);
        }

        /// <summary>
        /// Adds a event to a pipelines buffer to be uploaded. The API will return synchronously and the event
        /// will be uploaded in the background based on the pipeline configuration.
        /// </summary>
        /// <param name="event">Event to upload.</param>
        /// <returns>Result code for this API operation. Possible values are S_OK, E_PF_NOT_INITIALIZED, or E_FAIL.</returns>
        public PFResult EmitEvent(PFEvent pfEvent)
        {
            return InteropWrapper.Core.PFEventPipeline.PFEventPipelineEmitEvent(InteropHandle, pfEvent);
        }

        /// <summary>
        /// Adds an entity to an existing pipeline. All events emitted will be linked to this entity.
        /// </summary>
        /// <param name="entity">The Entity whose token will be used to make the PlayFab service requests in the background.</param>
        /// <returns>Result code for this API operation. Possible values are S_OK, E_PF_NOT_INITIALIZED or E_FAIL.</returns>
        public PFResult AddUploadingEntity(PFEntity entity)
        {
            return InteropWrapper.Core.PFEventPipeline.PFEventPipelineAddUploadingEntity(InteropHandle, entity.InteropHandle.Handle);
        }

        /// <summary>
        /// Remove an entity from an existing pipeline. If a valid Telemetry Key Configuration was added at pipeline creation
        /// it will switch to it.
        /// </summary>
        /// <returns>Result code for this API operation. Possible values are S_OK, E_PF_NOT_INITIALIZED, or E_FAIL.</returns>
        public PFResult RemoveUploadingEntity()
        {
            return InteropWrapper.Core.PFEventPipeline.PFEventPipelineRemoveUploadingEntity(InteropHandle);
        }

        /// <summary>
        /// Update an existing pipeline configuration.
        /// </summary>
        /// <param name="eventPipelineConfig">Struct that contains the new configuration of the event pipeline.</param>
        /// <returns>Result code for this API operation. Possible values are S_OK, E_PF_NOT_INITIALIZED, or E_FAIL.</returns>
        public PFResult UpdateConfiguration(PFEventPipelineConfig eventPipelineConfig)
        {
            return InteropWrapper.Core.PFEventPipeline.PFEventPipelineUpdateConfiguration(InteropHandle, eventPipelineConfig);
        }
    }
}
