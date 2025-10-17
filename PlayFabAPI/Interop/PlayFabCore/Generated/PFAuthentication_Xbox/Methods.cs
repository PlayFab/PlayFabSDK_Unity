using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithXUserAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const PFAuthenticationLoginWithXUserRequest *")] PFAuthenticationLoginWithXUserRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithXUserGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithXUserGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationReLoginWithXUserAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationLoginWithXUserRequest *")] PFAuthenticationLoginWithXUserRequest* request, XAsyncBlock* async);
    }
}
