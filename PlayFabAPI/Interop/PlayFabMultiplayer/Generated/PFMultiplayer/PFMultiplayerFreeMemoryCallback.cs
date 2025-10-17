using PlayFab.Interop;
using System.Runtime.InteropServices;

namespace PlayFab.Interop.Multiplayer
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void PFMultiplayerFreeMemoryCallback(void* pointer, [NativeTypeName("uint32_t")] uint memoryTypeId);
}
