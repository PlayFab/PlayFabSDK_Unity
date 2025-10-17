using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: NativeTypeName("HRESULT")]
    public unsafe delegate int PFPlatformLocalStorageWriteAsyncHandler(void* context, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("size_t")] ulong dataSize, [NativeTypeName("const void *")] void* data, XAsyncBlock* async);
}
