using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void PFGameSaveFilesUiOutOfStorageCallback([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, [NativeTypeName("uint64_t")] ulong requiredBytes, void* context);
}
