using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void PFEntityTokenExpiredEventHandler(void* context, [NativeTypeName("const PFEntityKey *")] PFEntityKey* entityKey);
}
