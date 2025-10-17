using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFLocalUserCreateHandleWithXboxUser([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("XUserHandle")] IntPtr user, void* customContext, [NativeTypeName("PFLocalUserHandle *")] IntPtr* localUserHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFLocalUserTryGetXUser([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, [NativeTypeName("XUserHandle *")] IntPtr* user);
    }
}
