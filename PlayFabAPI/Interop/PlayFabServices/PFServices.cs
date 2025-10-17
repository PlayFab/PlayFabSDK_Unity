using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport("PlayFabServices.Win32", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFServicesInitialize([NativeTypeName("XTaskQueueHandle")] IntPtr reserved, [NativeTypeName("HCInitArgs*")] HCInitArgs* initArgs);
    }
}
