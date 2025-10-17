using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void PFGameSaveFilesActiveDeviceChangedCallback([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, PFGameSaveDescriptor* activeDevice, void* context);
}
