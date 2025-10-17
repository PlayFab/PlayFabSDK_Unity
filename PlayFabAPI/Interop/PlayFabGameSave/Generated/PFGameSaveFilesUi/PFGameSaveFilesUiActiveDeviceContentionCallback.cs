using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void PFGameSaveFilesUiActiveDeviceContentionCallback([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, PFGameSaveDescriptor* localGameSave, PFGameSaveDescriptor* remoteGameSave, void* context);
}
