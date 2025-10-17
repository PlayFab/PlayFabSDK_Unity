using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [NativeTypeName("const uint32_t")]
        public const uint PFPlayStreamEventPipelineMaxEventsPerBatchDefault = 5;

        [NativeTypeName("const uint32_t")]
        public const uint PFPlayStreamEventPipelineMaxWaitTimeInSecondsDefault = 3;

        [NativeTypeName("const uint32_t")]
        public const uint PFPlayStreamEventPipelinePollDelayInMsDefault = 10;

        [NativeTypeName("const uint32_t")]
        public const uint PFTelemetryEventPipelineMaxEventsPerBatchDefault = 5;

        [NativeTypeName("const uint32_t")]
        public const uint PFTelemetryEventPipelineMaxWaitTimeInSecondsDefault = 3;

        [NativeTypeName("const uint32_t")]
        public const uint PFTelemetryEventPipelinePollDelayInMsDefault = 3000;

        [NativeTypeName("const bool")]
        public const byte PFTelemetryEventPipelineRetryOnDisconnectDefault = 1;

        [NativeTypeName("const size_t")]
        public const ulong PFEventPipelineBufferSizeDefault = 1024;

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEventPipelineCreateTelemetryPipelineHandleWithKey(PFEventPipelineTelemetryKeyConfig* eventPipelineTelemetryKeyConfig, [NativeTypeName("XTaskQueueHandle")] IntPtr queue, PFEventPipelineBatchUploadSucceededEventHandler eventPipelineBatchUploadedEventHandler, PFEventPipelineBatchUploadFailedEventHandler eventPipelineBatchFailedEventHandler, void* handlerContext, [NativeTypeName("PFEventPipelineHandle *")] IntPtr* eventPipelineHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEventPipelineCreateTelemetryPipelineHandleWithEntity([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("XTaskQueueHandle")] IntPtr queue, PFEventPipelineBatchUploadSucceededEventHandler eventPipelineBatchUploadedEventHandler, PFEventPipelineBatchUploadFailedEventHandler eventPipelineBatchFailedEventHandler, void* handlerContext, [NativeTypeName("PFEventPipelineHandle *")] IntPtr* eventPipelineHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEventPipelineCreatePlayStreamPipelineHandle([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("XTaskQueueHandle")] IntPtr queue, PFEventPipelineBatchUploadSucceededEventHandler eventPipelineBatchUploadedEventHandler, PFEventPipelineBatchUploadFailedEventHandler eventPipelineBatchFailedEventHandler, void* handlerContext, [NativeTypeName("PFEventPipelineHandle *")] IntPtr* eventPipelineHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEventPipelineDuplicateHandle([NativeTypeName("PFEventPipelineHandle")] IntPtr eventPipelineHandle, [NativeTypeName("PFEventPipelineHandle *")] IntPtr* duplicatedEventPipelineHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PFEventPipelineCloseHandle([NativeTypeName("PFEventPipelineHandle")] IntPtr eventPipelineHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEventPipelineEmitEvent([NativeTypeName("PFEventPipelineHandle")] IntPtr eventPipelineHandle, [NativeTypeName("const PFEvent *")] PFEvent* @event);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEventPipelineAddUploadingEntity([NativeTypeName("PFEventPipelineHandle")] IntPtr eventPipelineHandle, [NativeTypeName("PFEntityHandle")] IntPtr entityHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEventPipelineRemoveUploadingEntity([NativeTypeName("PFEventPipelineHandle")] IntPtr eventPipelineHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEventPipelineUpdateConfiguration([NativeTypeName("PFEventPipelineHandle")] IntPtr eventPipelineHandle, PFEventPipelineConfig eventPipelineConfig);
    }
}
