using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: NativeTypeName("HRESULT")]
    public unsafe delegate int PFPlatformLocalStorageReadAsyncHandler(void* context, [NativeTypeName("const char *")] sbyte* key, XAsyncBlock* async);
}
