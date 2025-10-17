using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void* PFMemAllocFunction([NativeTypeName("size_t")] ulong size, [NativeTypeName("uint32_t")] uint memoryTypeId);
}
