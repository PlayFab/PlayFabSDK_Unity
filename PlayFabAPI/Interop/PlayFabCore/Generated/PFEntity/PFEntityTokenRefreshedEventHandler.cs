using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void PFEntityTokenRefreshedEventHandler(void* context, [NativeTypeName("const PFEntityKey *")] PFEntityKey* entityKey, [NativeTypeName("const PFEntityToken *")] PFEntityToken* newToken);
}
