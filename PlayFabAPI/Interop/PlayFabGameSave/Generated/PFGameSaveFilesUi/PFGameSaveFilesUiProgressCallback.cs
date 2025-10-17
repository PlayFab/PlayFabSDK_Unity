using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void PFGameSaveFilesUiProgressCallback([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, PFGameSaveFilesSyncState syncState, void* context);
}
