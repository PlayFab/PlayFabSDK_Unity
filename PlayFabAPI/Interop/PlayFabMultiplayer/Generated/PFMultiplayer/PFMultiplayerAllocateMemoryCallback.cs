using PlayFab.Interop;
using System.Runtime.InteropServices;

namespace PlayFab.Interop.Multiplayer
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void* PFMultiplayerAllocateMemoryCallback([NativeTypeName("size_t")] ulong size, [NativeTypeName("uint32_t")] uint memoryTypeId);
}
