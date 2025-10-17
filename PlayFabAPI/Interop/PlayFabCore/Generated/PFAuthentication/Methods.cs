using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithAppleAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const PFAuthenticationLoginWithAppleRequest *")] PFAuthenticationLoginWithAppleRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithAppleGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithAppleGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationReLoginWithAppleAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationLoginWithAppleRequest *")] PFAuthenticationLoginWithAppleRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithBattleNetAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const PFAuthenticationLoginWithBattleNetRequest *")] PFAuthenticationLoginWithBattleNetRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithBattleNetGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithBattleNetGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationReLoginWithBattleNetAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationLoginWithBattleNetRequest *")] PFAuthenticationLoginWithBattleNetRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithCustomIDAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const PFAuthenticationLoginWithCustomIDRequest *")] PFAuthenticationLoginWithCustomIDRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithCustomIDGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithCustomIDGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationReLoginWithCustomIDAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationLoginWithCustomIDRequest *")] PFAuthenticationLoginWithCustomIDRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithFacebookAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const PFAuthenticationLoginWithFacebookRequest *")] PFAuthenticationLoginWithFacebookRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithFacebookGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithFacebookGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationReLoginWithFacebookAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationLoginWithFacebookRequest *")] PFAuthenticationLoginWithFacebookRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithGameCenterAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const PFAuthenticationLoginWithGameCenterRequest *")] PFAuthenticationLoginWithGameCenterRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithGameCenterGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithGameCenterGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationReLoginWithGameCenterAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationLoginWithGameCenterRequest *")] PFAuthenticationLoginWithGameCenterRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithGoogleAccountAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const PFAuthenticationLoginWithGoogleAccountRequest *")] PFAuthenticationLoginWithGoogleAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithGoogleAccountGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithGoogleAccountGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationReLoginWithGoogleAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationLoginWithGoogleAccountRequest *")] PFAuthenticationLoginWithGoogleAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithGooglePlayGamesServicesAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const PFAuthenticationLoginWithGooglePlayGamesServicesRequest *")] PFAuthenticationLoginWithGooglePlayGamesServicesRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithGooglePlayGamesServicesGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithGooglePlayGamesServicesGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationReLoginWithGooglePlayGamesServicesAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationLoginWithGooglePlayGamesServicesRequest *")] PFAuthenticationLoginWithGooglePlayGamesServicesRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithNintendoServiceAccountAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const PFAuthenticationLoginWithNintendoServiceAccountRequest *")] PFAuthenticationLoginWithNintendoServiceAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithNintendoServiceAccountGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithNintendoServiceAccountGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationReLoginWithNintendoServiceAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationLoginWithNintendoServiceAccountRequest *")] PFAuthenticationLoginWithNintendoServiceAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithOpenIdConnectAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const PFAuthenticationLoginWithOpenIdConnectRequest *")] PFAuthenticationLoginWithOpenIdConnectRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithOpenIdConnectGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithOpenIdConnectGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationReLoginWithOpenIdConnectAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationLoginWithOpenIdConnectRequest *")] PFAuthenticationLoginWithOpenIdConnectRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithPSNAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const PFAuthenticationLoginWithPSNRequest *")] PFAuthenticationLoginWithPSNRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithPSNGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithPSNGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationReLoginWithPSNAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationLoginWithPSNRequest *")] PFAuthenticationLoginWithPSNRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithSteamAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const PFAuthenticationLoginWithSteamRequest *")] PFAuthenticationLoginWithSteamRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithSteamGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithSteamGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationReLoginWithSteamAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationLoginWithSteamRequest *")] PFAuthenticationLoginWithSteamRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithXboxAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const PFAuthenticationLoginWithXboxRequest *")] PFAuthenticationLoginWithXboxRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithXboxGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationLoginWithXboxGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationReLoginWithXboxAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationLoginWithXboxRequest *")] PFAuthenticationLoginWithXboxRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithAndroidDeviceIDAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const char *")] sbyte* secretKey, [NativeTypeName("const PFAuthenticationServerLoginWithAndroidDeviceIDRequest *")] PFAuthenticationServerLoginWithAndroidDeviceIDRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithAndroidDeviceIDGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithAndroidDeviceIDGetResult(XAsyncBlock* async, [NativeTypeName("const PFAuthenticationEntityTokenResponse **")] PFAuthenticationEntityTokenResponse** entityTokenResponse, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithBattleNetAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const char *")] sbyte* secretKey, [NativeTypeName("const PFAuthenticationServerLoginWithBattleNetRequest *")] PFAuthenticationServerLoginWithBattleNetRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithBattleNetGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithBattleNetGetResult(XAsyncBlock* async, [NativeTypeName("const PFAuthenticationEntityTokenResponse **")] PFAuthenticationEntityTokenResponse** entityTokenResponse, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithCustomIDAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const char *")] sbyte* secretKey, [NativeTypeName("const PFAuthenticationServerLoginWithCustomIDRequest *")] PFAuthenticationServerLoginWithCustomIDRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithCustomIDGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithCustomIDGetResult(XAsyncBlock* async, [NativeTypeName("const PFAuthenticationEntityTokenResponse **")] PFAuthenticationEntityTokenResponse** entityTokenResponse, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithIOSDeviceIDAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const char *")] sbyte* secretKey, [NativeTypeName("const PFAuthenticationServerLoginWithIOSDeviceIDRequest *")] PFAuthenticationServerLoginWithIOSDeviceIDRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithIOSDeviceIDGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithIOSDeviceIDGetResult(XAsyncBlock* async, [NativeTypeName("const PFAuthenticationEntityTokenResponse **")] PFAuthenticationEntityTokenResponse** entityTokenResponse, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithPSNAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const char *")] sbyte* secretKey, [NativeTypeName("const PFAuthenticationServerLoginWithPSNRequest *")] PFAuthenticationServerLoginWithPSNRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithPSNGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithPSNGetResult(XAsyncBlock* async, [NativeTypeName("const PFAuthenticationEntityTokenResponse **")] PFAuthenticationEntityTokenResponse** entityTokenResponse, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithServerCustomIdAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const char *")] sbyte* secretKey, [NativeTypeName("const PFAuthenticationLoginWithServerCustomIdRequest *")] PFAuthenticationLoginWithServerCustomIdRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithServerCustomIdGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithServerCustomIdGetResult(XAsyncBlock* async, [NativeTypeName("const PFAuthenticationEntityTokenResponse **")] PFAuthenticationEntityTokenResponse** entityTokenResponse, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithSteamIdAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const char *")] sbyte* secretKey, [NativeTypeName("const PFAuthenticationLoginWithSteamIdRequest *")] PFAuthenticationLoginWithSteamIdRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithSteamIdGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithSteamIdGetResult(XAsyncBlock* async, [NativeTypeName("const PFAuthenticationEntityTokenResponse **")] PFAuthenticationEntityTokenResponse** entityTokenResponse, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithXboxAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const char *")] sbyte* secretKey, [NativeTypeName("const PFAuthenticationServerLoginWithXboxRequest *")] PFAuthenticationServerLoginWithXboxRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithXboxGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithXboxGetResult(XAsyncBlock* async, [NativeTypeName("const PFAuthenticationEntityTokenResponse **")] PFAuthenticationEntityTokenResponse** entityTokenResponse, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithXboxIdAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const char *")] sbyte* secretKey, [NativeTypeName("const PFAuthenticationLoginWithXboxIdRequest *")] PFAuthenticationLoginWithXboxIdRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithXboxIdGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationServerLoginWithXboxIdGetResult(XAsyncBlock* async, [NativeTypeName("const PFAuthenticationEntityTokenResponse **")] PFAuthenticationEntityTokenResponse** entityTokenResponse, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, [NativeTypeName("const PFAuthenticationLoginResult **")] PFAuthenticationLoginResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationAuthenticateGameServerWithCustomIdAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationAuthenticateCustomIdRequest *")] PFAuthenticationAuthenticateCustomIdRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationAuthenticateGameServerWithCustomIdGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle, [NativeTypeName("bool *")] byte* newlyCreated);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationDeleteAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationDeleteRequest *")] PFAuthenticationDeleteRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationGetEntityAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationGetEntityRequest *")] PFAuthenticationGetEntityRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationGetEntityGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationGetEntityWithSecretKeyAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const char *")] sbyte* secretKey, [NativeTypeName("const PFAuthenticationGetEntityRequest *")] PFAuthenticationGetEntityRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationGetEntityWithSecretKeyGetResult(XAsyncBlock* async, [NativeTypeName("PFEntityHandle *")] IntPtr* entityHandle);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationValidateEntityTokenAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAuthenticationValidateEntityTokenRequest *")] PFAuthenticationValidateEntityTokenRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationValidateEntityTokenGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabCoreLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAuthenticationValidateEntityTokenGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAuthenticationValidateEntityTokenResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);
    }
}
