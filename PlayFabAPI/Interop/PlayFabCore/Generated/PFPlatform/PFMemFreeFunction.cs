using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void PFMemFreeFunction(void* pointer, [NativeTypeName("uint32_t")] uint memoryTypeId);
}
