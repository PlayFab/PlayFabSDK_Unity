using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFPlatformSpecificClientAndroidDevicePushNotificationRegistrationAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFPlatformSpecificAndroidDevicePushNotificationRegistrationRequest *")] PFPlatformSpecificAndroidDevicePushNotificationRegistrationRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFPlatformSpecificClientRegisterForIOSPushNotificationAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFPlatformSpecificRegisterForIOSPushNotificationRequest *")] PFPlatformSpecificRegisterForIOSPushNotificationRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFPlatformSpecificServerAwardSteamAchievementAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFPlatformSpecificAwardSteamAchievementRequest *")] PFPlatformSpecificAwardSteamAchievementRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFPlatformSpecificServerAwardSteamAchievementGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFPlatformSpecificServerAwardSteamAchievementGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFPlatformSpecificAwardSteamAchievementResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);
    }
}
