using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: NativeTypeName("HRESULT")]
    public unsafe delegate int PFLocalUserLoginHandler([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, [NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("PFEntityHandle")] IntPtr existingEntityHandle, XAsyncBlock* async);
}
