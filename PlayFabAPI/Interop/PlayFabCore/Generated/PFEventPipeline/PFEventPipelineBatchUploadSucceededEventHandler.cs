using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void PFEventPipelineBatchUploadSucceededEventHandler(void* context, [NativeTypeName("const PFUploadedEvent *const *")] PFUploadedEvent** eventPipelineUploadedEvents, [NativeTypeName("size_t")] ulong eventPipelineUploadedEventsCount);
}
