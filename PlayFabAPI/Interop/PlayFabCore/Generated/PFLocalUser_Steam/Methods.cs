using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFLocalUserCreateHandleWithSteamUser([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, void* customContext, [NativeTypeName("PFLocalUserHandle *")] IntPtr* localUserHandle);
    }
}
