// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;

namespace PlayFab
{
    /// <summary>
    /// Handle to an event pipeline (TitlePlayer, Title, etc.). When no longer needed, the handle must be closed with PFEventPipelineCloseHandle.
    /// </summary>
    public readonly struct PFEventPipelineHandle
    {
        public readonly IntPtr Handle;

        internal PFEventPipelineHandle(IntPtr handle)
        {
            Handle = handle;
        }
    }

    /// <summary>
    /// Event to be uploaded to PlayFab.
    /// </summary>
    public struct PFEvent
    {
        /// <summary>
        /// Entity associated with the event. If null, the event will apply to the calling entity.
        /// </summary>
        public PFEntityKey? Entity;

        /// <summary>
        /// The namespace in which the event is defined.
        /// </summary>
        public string EventNamespace;

        /// <summary>
        /// The name of the event.
        /// </summary>
        public string Name;

        /// <summary>
        /// Client assigned identifier associated with event. Not required but may be useful for tracking or tracing.
        /// If a clientId is not provided, the SDK will automatically assign one.
        /// </summary>
        public string? ClientId;

        /// <summary>
        /// Arbitrary JSON data associated with the event.
        /// </summary>
        public string PayloadJson;

        internal unsafe PFEvent(Interop.PFEvent interop)
        {
            Entity = (interop.entity == null) ? null : new(*interop.entity);
            EventNamespace = InteropWrapper.WrapperHelpers.InteropToString(interop.eventNamespace)!;
            Name = InteropWrapper.WrapperHelpers.InteropToString(interop.name)!;
            ClientId = (interop.clientId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.clientId);
            PayloadJson = InteropWrapper.WrapperHelpers.InteropToString(interop.payloadJson)!;
        }

        internal unsafe static void ToInterop(PFEvent self, Interop.PFEvent* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Entity != null)
            {
                interop->entity = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.Entity.Value, interop->entity, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.EventNamespace, &interop->eventNamespace, buffer);
            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

            if (self.ClientId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ClientId, &interop->clientId, buffer);
            }

            InteropWrapper.WrapperHelpers.StringToInterop(self.PayloadJson, &interop->payloadJson, buffer);
        }
    }

    /// <summary>
    /// Event that has been uploaded to PlayFab. Associates the service assigned ID with the clientId provided when the event was emitted.
    /// </summary>
    public struct PFUploadedEvent
    {
        /// <summary>
        /// Id assigned by the client prior to the event being uploaded.
        /// </summary>
        public string ClientId;

        /// <summary>
        /// Unique Id assigned by the PlayFab server for the event.
        /// </summary>
        public string ServiceId;

        internal unsafe PFUploadedEvent(Interop.PFUploadedEvent interop)
        {
            ClientId = InteropWrapper.WrapperHelpers.InteropToString(interop.clientId)!;
            ServiceId = InteropWrapper.WrapperHelpers.InteropToString(interop.serviceId)!;
        }

        internal unsafe static void ToInterop(PFUploadedEvent self, Interop.PFUploadedEvent* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;
            InteropWrapper.WrapperHelpers.StringToInterop(self.ClientId, &interop->clientId, buffer);
            InteropWrapper.WrapperHelpers.StringToInterop(self.ServiceId, &interop->serviceId, buffer);
        }
    }

    /// <summary>
    /// Configuration struct that defines the properties required for using Telemetry Key.
    /// </summary>
    public struct PFEventPipelineTelemetryKeyConfig
    {
        /// <summary>
        /// The Key created to send PlayFab event requests without an associated entity.
        /// </summary>
        public string TelemetryKey;

        /// <summary>
        /// Service Config to be used with telemetry key.
        /// </summary>
        public PFServiceConfigHandle ServiceConfigHandle;

        internal unsafe PFEventPipelineTelemetryKeyConfig(Interop.PFEventPipelineTelemetryKeyConfig interop)
        {
            TelemetryKey = InteropWrapper.WrapperHelpers.InteropToString(interop.telemetryKey)!;
            ServiceConfigHandle = new PFServiceConfigHandle(interop.serviceConfigHandle);
        }

        internal unsafe static void ToInterop(PFEventPipelineTelemetryKeyConfig self, Interop.PFEventPipelineTelemetryKeyConfig* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;
            InteropWrapper.WrapperHelpers.StringToInterop(self.TelemetryKey, &interop->telemetryKey, buffer);
            interop->serviceConfigHandle = self.ServiceConfigHandle.Handle;
        }
    }

    /// <summary>
    /// Defines the Event Pipeline configuration.
    /// </summary>
    public struct PFEventPipelineConfig
    {
        /// <summary>
        /// The maximum number events that will be batched before writing them to PlayFab. If sent null, default value will be used (5 for Telemetry / 5 for PlayStream).
        /// </summary>
        public uint? MaxEventsPerBatch;

        /// <summary>
        /// The maximum time the pipeline will wait before sending out an incomplete batch. If sent null, default value will be used (3 for Telemetry / 3 for PlayStream).
        /// </summary>
        public uint? MaxWaitTimeInSeconds;

        /// <summary>
        /// How long the pipeline will wait to read from the event buffer again after emptying it. If sent null, default value will be used (10 for Telemetry / 10 for PlayStream).
        /// </summary>
        public uint? PollDelayInMs;

        /// <summary>
        /// The event pipeline will send events using GZIP compression with the level specified. If sent null, no compression will be made.
        /// </summary>
        public HCCompressionLevel? CompressionLevel;

        /// <summary>
        /// The event pipeline will retry sending events that failed due to lost connection. If sent null, default behavior will be to retry (true) (not available for PlayStream).
        /// </summary>
        public bool? RetryOnDisconnect;

        /// <summary>
        /// The limit of the amount of events in the pipeline's buffer. If sent null, default value will be used (1024 for either type).
        /// </summary>
        public ulong? BufferSize;

        internal unsafe PFEventPipelineConfig(Interop.PFEventPipelineConfig interop)
        {
            MaxEventsPerBatch = (interop.maxEventsPerBatch == null) ? null : *interop.maxEventsPerBatch;
            MaxWaitTimeInSeconds = (interop.maxWaitTimeInSeconds == null) ? null : *interop.maxWaitTimeInSeconds;
            PollDelayInMs = (interop.pollDelayInMs == null) ? null : *interop.pollDelayInMs;
            CompressionLevel = (interop.compressionLevel == null) ? null : (HCCompressionLevel?)(*interop.compressionLevel);
            RetryOnDisconnect = (interop.retryOnDisconnect == null) ? null : InteropWrapper.WrapperHelpers.InteropToBool(*interop.retryOnDisconnect);
            BufferSize = (interop.bufferSize == null) ? null : *interop.bufferSize;
        }

        internal unsafe static void ToInterop(PFEventPipelineConfig self, Interop.PFEventPipelineConfig* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.MaxEventsPerBatch != null)
            {
                interop->maxEventsPerBatch = (uint*)buffer.AddBuffer(sizeof(uint));
                *interop->maxEventsPerBatch = self.MaxEventsPerBatch.Value;
            }

            if (self.MaxWaitTimeInSeconds != null)
            {
                interop->maxWaitTimeInSeconds = (uint*)buffer.AddBuffer(sizeof(uint));
                *interop->maxWaitTimeInSeconds = self.MaxWaitTimeInSeconds.Value;
            }

            if (self.PollDelayInMs != null)
            {
                interop->pollDelayInMs = (uint*)buffer.AddBuffer(sizeof(uint));
                *interop->pollDelayInMs = self.PollDelayInMs.Value;
            }

            if (self.CompressionLevel != null)
            {
                interop->compressionLevel = (Interop.HCCompressionLevel*)buffer.AddBuffer(sizeof(Interop.HCCompressionLevel));
                *interop->compressionLevel = (Interop.HCCompressionLevel)self.CompressionLevel.Value;
            }

            if (self.RetryOnDisconnect != null)
            {
                interop->retryOnDisconnect = (byte*)buffer.AddBuffer(sizeof(byte));
                *interop->retryOnDisconnect = InteropWrapper.WrapperHelpers.BoolToInterop(self.RetryOnDisconnect.Value);
            }

            if (self.BufferSize != null)
            {
                interop->bufferSize = (ulong*)buffer.AddBuffer(sizeof(ulong));
                *interop->bufferSize = self.BufferSize.Value;
            }
        }
    }

    /// <summary>
    /// A handler invoked when the SDK successfully uploads a batch of events.
    /// </summary>
    /// <param name="context">Optional context pointer to data used by the event handler.</param>
    /// <param name="eventPipelineUploadedEvents">The array of PFEventPipelineUploadedEvents that was uploaded.</param>
    /// <remarks>
    /// Arguments besides context are owned by the SDK and only guaranteed to be valid within the callback.
    /// </remarks>
    public delegate void PFEventPipelineBatchUploadSucceededEventHandler(
        object context,
        PFUploadedEvent[] eventPipelineUploadedEvents
    );

    /// <summary>
    /// A handler invoked when the SDK has attempted but failed to upload a batch of event pipeline events.
    /// It is up to the client to resubmit failed events as necessary using PFEventPipelineEmitEvent, though depending on the nature
    /// of the failure, resubmitting directly may not resolve the issue.
    /// </summary>
    /// <param name="context">Optional context pointer to data used by the event handler.</param>
    /// <param name="translatedUploadError">Translated upload error.</param>
    /// <param name="errorMessage">Message describing the upload error.</param>
    /// <param name="failedEvents">Events that were in the failed batch.</param>
    /// <remarks>
    /// Arguments besides context are owned by the SDK and only guaranteed to be valid within the callback.
    /// </remarks>
    public delegate void PFEventPipelineBatchUploadFailedEventHandler(
        object context,
        int translatedUploadError,
        string errorMessage,
        PFEvent[] failedEvents
    );
}
