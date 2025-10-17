using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFLocalUserCreateHandleWithPersistedLocalId([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const char *")] sbyte* persistedLocalId, PFLocalUserLoginHandler loginHandler, void* customContext, [NativeTypeName("PFLocalUserHandle *")] IntPtr* localUserHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFLocalUserDuplicateHandle([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, [NativeTypeName("PFLocalUserHandle *")] IntPtr* duplicatedHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PFLocalUserCloseHandle([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("int32_t")]
        public static extern int PFLocalUserHandleCompare([NativeTypeName("PFLocalUserHandle")] IntPtr user1, [NativeTypeName("PFLocalUserHandle")] IntPtr user2);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFLocalUserGetServiceConfigHandle([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, [NativeTypeName("PFServiceConfigHandle *")] IntPtr* serviceConfigHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFLocalUserGetLocalIdSize([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, [NativeTypeName("size_t *")] ulong* localIdSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFLocalUserGetLocalId([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, [NativeTypeName("size_t")] ulong localIdSize, [NativeTypeName("char *")] sbyte* localIdBuffer, [NativeTypeName("size_t *")] ulong* localIdUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFLocalUserGetCustomContext([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, void** customContext);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFLocalUserTryGetEntityHandle([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFLocalUserLoginAsync([NativeTypeName("PFLocalUserHandle")] IntPtr localUserHandle, byte createAccount, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFLocalUserLoginGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFLocalUserLoginGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);
    }
}
