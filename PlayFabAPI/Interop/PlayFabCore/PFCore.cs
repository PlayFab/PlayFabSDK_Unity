using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport("PlayFabCore.Win32", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFInitialize([NativeTypeName("XTaskQueueHandle")] IntPtr backgroundQueue, [NativeTypeName("JavaVM*")] IntPtr javaVm, [NativeTypeName("jobject")] IntPtr applicationContext);
    }
}
