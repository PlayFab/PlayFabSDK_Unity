// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace PlayFab.InteropWrapper.Core
{
    public static partial class PFEventPipeline
    {
        public static PFResult<PFEventPipelineHandle> PFEventPipelineCreateTelemetryPipelineHandleWithKey(
            PFEventPipelineTelemetryKeyConfig eventPipelineTelemetryKeyConfig,
            PFEventPipelineBatchUploadSucceededEventHandler eventPipelineBatchUploadedEventHandler,
            PFEventPipelineBatchUploadFailedEventHandler eventPipelineBatchFailedEventHandler,
            object handlerContext)
        {
            IntPtr internalContext = _PFEventPipelineBatchUploadSucceededEventHandlerManager.GetUniqueInternalContext();

            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFEventPipelineTelemetryKeyConfig* configInterop = stackalloc Interop.PFEventPipelineTelemetryKeyConfig[1];
                PFEventPipelineTelemetryKeyConfig.ToInterop(eventPipelineTelemetryKeyConfig, configInterop, disposableBuffer);

                IntPtr* eventPipelineHandleInterop = stackalloc IntPtr[1];
                int hr = Interop.Methods.PFEventPipelineCreateTelemetryPipelineHandleWithKey(
                    configInterop,
                    AsyncHelpers.DefaultQueue.handle.intPtr,
                    _PFEventPipelineBatchUploadSucceededEventHandlerManager.GetInteropCallback(),
                    _PFEventPipelineBatchUploadFailedEventHandlerManager.GetInteropCallback(),
                    (void*)internalContext,
                    eventPipelineHandleInterop);

                if (HRESULT.Succeeded(hr))
                {
                    var eventPipelineHandle = new PFEventPipelineHandle(*eventPipelineHandleInterop);
                    _PFEventPipelineBatchUploadSucceededEventHandlerManager.AddPipeline(eventPipelineHandle, eventPipelineBatchUploadedEventHandler, handlerContext, internalContext);
                    _PFEventPipelineBatchUploadFailedEventHandlerManager.AddPipeline(eventPipelineHandle, eventPipelineBatchFailedEventHandler, handlerContext, internalContext);
                    return new(eventPipelineHandle, hr);
                }

                return new(hr);
            }
        }

        public static PFResult<PFEventPipelineHandle> PFEventPipelineCreateTelemetryPipelineHandleWithEntity(
            PFEntityHandle entityHandle,
            PFEventPipelineBatchUploadSucceededEventHandler eventPipelineBatchUploadedEventHandler,
            PFEventPipelineBatchUploadFailedEventHandler eventPipelineBatchFailedEventHandler,
            object handlerContext)
        {
            IntPtr internalContext = _PFEventPipelineBatchUploadSucceededEventHandlerManager.GetUniqueInternalContext();

            unsafe
            {
                IntPtr* eventPipelineHandleInterop = stackalloc IntPtr[1];
                int hr = Interop.Methods.PFEventPipelineCreateTelemetryPipelineHandleWithEntity(
                    entityHandle.Handle,
                    AsyncHelpers.DefaultQueue.handle.intPtr,
                    _PFEventPipelineBatchUploadSucceededEventHandlerManager.GetInteropCallback(),
                    _PFEventPipelineBatchUploadFailedEventHandlerManager.GetInteropCallback(),
                    (void*)internalContext,
                    eventPipelineHandleInterop);

                if (HRESULT.Succeeded(hr))
                {
                    var eventPipelineHandle = new PFEventPipelineHandle(*eventPipelineHandleInterop);
                    _PFEventPipelineBatchUploadSucceededEventHandlerManager.AddPipeline(eventPipelineHandle, eventPipelineBatchUploadedEventHandler, handlerContext, internalContext);
                    _PFEventPipelineBatchUploadFailedEventHandlerManager.AddPipeline(eventPipelineHandle, eventPipelineBatchFailedEventHandler, handlerContext, internalContext);
                    return new(eventPipelineHandle, hr);
                }

                return new(hr);
            }
        }

        public static PFResult<PFEventPipelineHandle> PFEventPipelineCreatePlayStreamPipelineHandle(
            PFEntityHandle entityHandle,
            PFEventPipelineBatchUploadSucceededEventHandler eventPipelineBatchUploadedEventHandler,
            PFEventPipelineBatchUploadFailedEventHandler eventPipelineBatchFailedEventHandler,
            object handlerContext)
        {
            IntPtr internalContext = _PFEventPipelineBatchUploadSucceededEventHandlerManager.GetUniqueInternalContext();

            unsafe
            {
                IntPtr* eventPipelineHandleInterop = stackalloc IntPtr[1];
                int hr = Interop.Methods.PFEventPipelineCreatePlayStreamPipelineHandle(
                    entityHandle.Handle,
                    AsyncHelpers.DefaultQueue.handle.intPtr,
                    _PFEventPipelineBatchUploadSucceededEventHandlerManager.GetInteropCallback(),
                    _PFEventPipelineBatchUploadFailedEventHandlerManager.GetInteropCallback(),
                    (void*)internalContext,
                    eventPipelineHandleInterop);

                if (HRESULT.Succeeded(hr))
                {
                    var eventPipelineHandle = new PFEventPipelineHandle(*eventPipelineHandleInterop);
                    _PFEventPipelineBatchUploadSucceededEventHandlerManager.AddPipeline(eventPipelineHandle, eventPipelineBatchUploadedEventHandler, handlerContext, internalContext);
                    _PFEventPipelineBatchUploadFailedEventHandlerManager.AddPipeline(eventPipelineHandle, eventPipelineBatchFailedEventHandler, handlerContext, internalContext);
                    return new(eventPipelineHandle, hr);
                }

                return new(hr);
            }
        }

        public static PFResult<PFEventPipelineHandle> PFEventPipelineDuplicateHandle(PFEventPipelineHandle eventPipelineHandle)
        {
            unsafe
            {
                IntPtr* duplicatedEventPipelineHandle = stackalloc IntPtr[1];
                int hr = Interop.Methods.PFEventPipelineDuplicateHandle(eventPipelineHandle.Handle, duplicatedEventPipelineHandle);

                return HRESULT.Failed(hr) ? new(hr)
                                          : new(new PFEventPipelineHandle(*duplicatedEventPipelineHandle), hr);
            }
        }

        public static void PFEventPipelineCloseHandle(PFEventPipelineHandle eventPipelineHandle)
        {
            Interop.Methods.PFEventPipelineCloseHandle(eventPipelineHandle.Handle);
            _PFEventPipelineBatchUploadFailedEventHandlerManager.RemoveCallback(new(){Id = eventPipelineHandle.Handle});
            _PFEventPipelineBatchUploadSucceededEventHandlerManager.RemoveCallback(new(){Id = eventPipelineHandle.Handle});
        }

        public static PFResult PFEventPipelineEmitEvent(PFEventPipelineHandle eventPipelineHandle, PFEvent pfEvent)
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFEvent* pfEventInterop = stackalloc Interop.PFEvent[1];
                PFEvent.ToInterop(pfEvent, pfEventInterop, disposableBuffer);
                int hr = Interop.Methods.PFEventPipelineEmitEvent(eventPipelineHandle.Handle, pfEventInterop);
                return new PFResult(hr);
            }
        }

        public static PFResult PFEventPipelineAddUploadingEntity(PFEventPipelineHandle eventPipelineHandle, IntPtr entityHandle)
        {
            unsafe
            {
                int hr = Interop.Methods.PFEventPipelineAddUploadingEntity(eventPipelineHandle.Handle, entityHandle);
                return new PFResult(hr);
            }
        }

        public static PFResult PFEventPipelineRemoveUploadingEntity(PFEventPipelineHandle eventPipelineHandle)
        {
            unsafe
            {
                int hr = Interop.Methods.PFEventPipelineRemoveUploadingEntity(eventPipelineHandle.Handle);
                return new PFResult(hr);
            }
        }

        public static PFResult PFEventPipelineUpdateConfiguration(PFEventPipelineHandle eventPipelineHandle, PFEventPipelineConfig eventPipelineConfig)
        {
            unsafe
            {
                using DisposableBuffer disposableBuffer = new();
                Interop.PFEventPipelineConfig* eventPipelineConfigInterop = stackalloc Interop.PFEventPipelineConfig[1];
                PFEventPipelineConfig.ToInterop(eventPipelineConfig, eventPipelineConfigInterop, disposableBuffer);
                int hr = Interop.Methods.PFEventPipelineUpdateConfiguration(eventPipelineHandle.Handle, *eventPipelineConfigInterop);
                return new PFResult(hr);
            }
        }

        private static readonly PFEventPipelineBatchUploadSucceededEventHandlerManager _PFEventPipelineBatchUploadSucceededEventHandlerManager = new();
        private static readonly PFEventPipelineBatchUploadFailedEventHandlerManager _PFEventPipelineBatchUploadFailedEventHandlerManager = new();        

        private class PFEventPipelineBatchUploadSucceededEventHandlerManager :
            InteropMultiCallbackManager<PFEventPipelineBatchUploadSucceededEventHandler>
        {
            private Interop.PFEventPipelineBatchUploadSucceededEventHandler _interopCallback;

            internal unsafe Interop.PFEventPipelineBatchUploadSucceededEventHandler GetInteropCallback()
            {
                if (_interopCallback == null)
                {
                    _interopCallback = new Interop.PFEventPipelineBatchUploadSucceededEventHandler(InteropPInvokeCallback);
                }
                return _interopCallback;
            }
            
            internal unsafe void InteropPInvokeCallback(void* context, Interop.PFUploadedEvent** eventPipelineUploadedEvents, ulong eventPipelineUploadedEventsCount)
            {
                IntPtr id = new(context);
                if (!InternalContextToCallbackId.ContainsKey(id)) return;
                if (!CallbackIdToHandler.ContainsKey(InternalContextToCallbackId[id])) return;

                var uploadedEvents = WrapperHelpers.InteropToArray(*eventPipelineUploadedEvents, eventPipelineUploadedEventsCount, elem => new PFUploadedEvent(elem));

                IssueEventCallback(InternalContextToCallbackId[id], uploadedEvents);
            }

            internal void AddPipeline(PFEventPipelineHandle eventPipelineHandle, PFEventPipelineBatchUploadSucceededEventHandler callback, object context, IntPtr internalContext)
            {
                AddCallbackForId(eventPipelineHandle.Handle, callback, context, internalContext);
            }

            private void IssueEventCallback(IntPtr id, PFUploadedEvent[] uploadedEvents)
            {
                CallbackIdToHandler[id].Callback.Invoke(CallbackIdToHandler[id].Context, uploadedEvents);
            }
        }

        private class PFEventPipelineBatchUploadFailedEventHandlerManager :
            InteropMultiCallbackManager<PFEventPipelineBatchUploadFailedEventHandler>
        {
            private Interop.PFEventPipelineBatchUploadFailedEventHandler _interopCallback;

            internal unsafe Interop.PFEventPipelineBatchUploadFailedEventHandler GetInteropCallback()
            {
                if (_interopCallback == null)
                {
                    _interopCallback = new Interop.PFEventPipelineBatchUploadFailedEventHandler(InteropPInvokeCallback);
                }
                return _interopCallback;
            }
            
            internal unsafe void InteropPInvokeCallback(void* context, int translatedUploadError, sbyte* errorMessage, Interop.PFEvent** eventPipelineFailedEvents, ulong failedEventsCount)
            {
                IntPtr id = new(context);
                if (!InternalContextToCallbackId.ContainsKey(id)) return;
                if (!CallbackIdToHandler.ContainsKey(InternalContextToCallbackId[id])) return;

                var failedEvents = WrapperHelpers.InteropToArray(*eventPipelineFailedEvents, failedEventsCount, elem => new PFEvent(elem));

                IssueEventCallback(id, translatedUploadError, WrapperHelpers.InteropToString(errorMessage), failedEvents);
            }

            internal void AddPipeline(PFEventPipelineHandle eventPipelineHandle, PFEventPipelineBatchUploadFailedEventHandler callback, object context, IntPtr internalContext)
            {
                AddCallbackForId(eventPipelineHandle.Handle, callback, context, internalContext);
            }

            private unsafe void IssueEventCallback(IntPtr id, int translatedUploadError, string errorMessage, PFEvent[] failedEvents)
            {
                CallbackIdToHandler[id].Callback.Invoke(CallbackIdToHandler[id].Context, translatedUploadError, errorMessage, failedEvents);
            }
        }
    }
}
