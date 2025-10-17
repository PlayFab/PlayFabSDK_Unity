using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void PFGameSaveFilesUiSyncFailedCallback([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, PFGameSaveFilesSyncState syncState, [NativeTypeName("HRESULT")] int error, void* context);
}
