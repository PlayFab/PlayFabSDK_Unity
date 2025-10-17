using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFSetHttpRetrySettings([NativeTypeName("const PFHttpRetrySettings *")] PFHttpRetrySettings* settings);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGetHttpRetrySettings(PFHttpRetrySettings* settings);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFSetHttpSettings([NativeTypeName("const PFHttpSettings *")] PFHttpSettings* settings);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFGetHttpSettings(PFHttpSettings* settings);
    }
}
