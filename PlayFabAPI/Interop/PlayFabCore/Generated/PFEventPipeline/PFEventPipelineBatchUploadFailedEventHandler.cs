using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void PFEventPipelineBatchUploadFailedEventHandler(void* context, [NativeTypeName("HRESULT")] int translatedUploadError, [NativeTypeName("const char *")] sbyte* errorMessage, [NativeTypeName("const PFEvent *const *")] PFEvent** failedEvents, [NativeTypeName("size_t")] ulong failedEventsCount);
}
