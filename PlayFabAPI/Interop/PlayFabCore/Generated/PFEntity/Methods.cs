using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [NativeTypeName("const char *")]
        public static ReadOnlySpan<byte> PFEntityTitlePlayerEntityType => new byte[] { 0x74, 0x69, 0x74, 0x6C, 0x65, 0x5F, 0x70, 0x6C, 0x61, 0x79, 0x65, 0x72, 0x5F, 0x61, 0x63, 0x63, 0x6F, 0x75, 0x6E, 0x74, 0x00 };

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEntityDuplicateHandle([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("PFEntityHandle *")] IntPtr* duplicatedEntityHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PFEntityCloseHandle([NativeTypeName("PFEntityHandle")] IntPtr entityHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEntityGetEntityTokenAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEntityGetEntityTokenResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEntityGetEntityTokenResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFEntityToken **")] PFEntityToken** entityToken, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEntityGetSecretKeySize([NativeTypeName("PFEntityHandle")] IntPtr handle, [NativeTypeName("size_t *")] ulong* secretKeySize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEntityGetSecretKey([NativeTypeName("PFEntityHandle")] IntPtr handle, [NativeTypeName("size_t")] ulong secretKeySize, [NativeTypeName("char *")] sbyte* secretKey, [NativeTypeName("size_t *")] ulong* secretKeyUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEntityGetEntityKeySize([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEntityGetEntityKey([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFEntityKey **")] PFEntityKey** entityKey, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEntityIsTitlePlayer([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("bool *")] byte* isTitlePlayer);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEntityGetAPIEndpointSize([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("size_t *")] ulong* apiEndpointSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEntityGetAPIEndpoint([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("size_t")] ulong apiEndpointSize, [NativeTypeName("char *")] sbyte* apiEndpoint, [NativeTypeName("size_t *")] ulong* apiEndpointUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEntityGetTitleIdSize([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("size_t *")] ulong* titleIdSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEntityGetTitleId([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("size_t")] ulong titleIdSize, [NativeTypeName("char *")] sbyte* titleIdBuffer, [NativeTypeName("size_t *")] ulong* titleIdUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEntityRegisterTokenExpiredEventHandler([NativeTypeName("XTaskQueueHandle")] IntPtr queue, void* context, PFEntityTokenExpiredEventHandler handler, [NativeTypeName("PFRegistrationToken *")] ulong* token);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PFEntityUnregisterTokenExpiredEventHandler([NativeTypeName("PFRegistrationToken")] ulong token);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFEntityRegisterTokenRefreshedEventHandler([NativeTypeName("XTaskQueueHandle")] IntPtr queue, void* context, PFEntityTokenRefreshedEventHandler handler, [NativeTypeName("PFRegistrationToken *")] ulong* token);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PFEntityUnregisterTokenRefreshedEventHandler([NativeTypeName("PFRegistrationToken")] ulong token);
    }
}
