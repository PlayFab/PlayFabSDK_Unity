using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFServiceConfigCreateHandle([NativeTypeName("const char *")] sbyte* apiEndpoint, [NativeTypeName("const char *")] sbyte* playFabTitleId, [NativeTypeName("PFServiceConfigHandle *")] IntPtr* serviceConfigHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFServiceConfigDuplicateHandle([NativeTypeName("PFServiceConfigHandle")] IntPtr handle, [NativeTypeName("PFServiceConfigHandle *")] IntPtr* duplicatedHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PFServiceConfigCloseHandle([NativeTypeName("PFServiceConfigHandle")] IntPtr handle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFServiceConfigGetAPIEndpointSize([NativeTypeName("PFServiceConfigHandle")] IntPtr handle, [NativeTypeName("size_t *")] ulong* apiEndpointSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFServiceConfigGetAPIEndpoint([NativeTypeName("PFServiceConfigHandle")] IntPtr handle, [NativeTypeName("size_t")] ulong apiEndpointSize, [NativeTypeName("char *")] sbyte* apiEndpoint, [NativeTypeName("size_t *")] ulong* apiEndpointUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFServiceConfigGetTitleIdSize([NativeTypeName("PFServiceConfigHandle")] IntPtr handle, [NativeTypeName("size_t *")] ulong* titleIdSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFServiceConfigGetTitleId([NativeTypeName("PFServiceConfigHandle")] IntPtr handle, [NativeTypeName("size_t")] ulong titleIdSize, [NativeTypeName("char *")] sbyte* titleId, [NativeTypeName("size_t *")] ulong* titleIdUsed);
    }
}
