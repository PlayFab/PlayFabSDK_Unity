using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(XGameRuntimeLibName, CallingConvention = CallingConvention.StdCall)]
        public static extern int XGameRuntimeInitialize();

        [DllImport(XGameRuntimeLibName, CallingConvention = CallingConvention.StdCall)]
        public static extern void XGameRuntimeUninitialize();
    }
}
