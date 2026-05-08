using System;
using System.Runtime.InteropServices;

namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientAddOrUpdateContactEmailAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementAddOrUpdateContactEmailRequest *")] PFAccountManagementAddOrUpdateContactEmailRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientAddUsernamePasswordAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementAddUsernamePasswordRequest *")] PFAccountManagementAddUsernamePasswordRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientAddUsernamePasswordGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientAddUsernamePasswordGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementAddUsernamePasswordResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetAccountInfoAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetAccountInfoRequest *")] PFAccountManagementGetAccountInfoRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetAccountInfoGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetAccountInfoGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetAccountInfoResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayerCombinedInfoAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayerCombinedInfoRequest *")] PFAccountManagementGetPlayerCombinedInfoRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayerCombinedInfoGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayerCombinedInfoGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayerCombinedInfoResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayerProfileAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayerProfileRequest *")] PFAccountManagementGetPlayerProfileRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayerProfileGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayerProfileGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayerProfileResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromBattleNetAccountIdsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest *")] PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromBattleNetAccountIdsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromBattleNetAccountIdsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromFacebookIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest *")] PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromFacebookIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromFacebookIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromFacebookIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromFacebookInstantGamesIdsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest *")] PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromFacebookInstantGamesIdsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromFacebookInstantGamesIdsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromGameCenterIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromGameCenterIDsRequest *")] PFAccountManagementGetPlayFabIDsFromGameCenterIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromGameCenterIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromGameCenterIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromGameCenterIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromGoogleIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromGoogleIDsRequest *")] PFAccountManagementGetPlayFabIDsFromGoogleIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromGoogleIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromGoogleIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromGoogleIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromGooglePlayGamesPlayerIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsRequest *")] PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromGooglePlayGamesPlayerIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromGooglePlayGamesPlayerIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromKongregateIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromKongregateIDsRequest *")] PFAccountManagementGetPlayFabIDsFromKongregateIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromKongregateIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromKongregateIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromKongregateIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromNintendoServiceAccountIdsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest *")] PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromNintendoServiceAccountIdsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromNintendoServiceAccountIdsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromNintendoSwitchDeviceIdsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest *")] PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromNintendoSwitchDeviceIdsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromNintendoSwitchDeviceIdsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromPSNAccountIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest *")] PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromPSNAccountIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromPSNAccountIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromPSNOnlineIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest *")] PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromPSNOnlineIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromPSNOnlineIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromSteamIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromSteamIDsRequest *")] PFAccountManagementGetPlayFabIDsFromSteamIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromSteamIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromSteamIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromSteamIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromSteamNamesAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromSteamNamesRequest *")] PFAccountManagementGetPlayFabIDsFromSteamNamesRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromSteamNamesGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromSteamNamesGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromSteamNamesResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromTwitchIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest *")] PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromTwitchIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromTwitchIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromTwitchIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromXboxLiveIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest *")] PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromXboxLiveIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientGetPlayFabIDsFromXboxLiveIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkAndroidDeviceIDAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementLinkAndroidDeviceIDRequest *")] PFAccountManagementLinkAndroidDeviceIDRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkAppleAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementLinkAppleRequest *")] PFAccountManagementLinkAppleRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkBattleNetAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementClientLinkBattleNetAccountRequest *")] PFAccountManagementClientLinkBattleNetAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkCustomIDAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementLinkCustomIDRequest *")] PFAccountManagementLinkCustomIDRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkFacebookAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementLinkFacebookAccountRequest *")] PFAccountManagementLinkFacebookAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkFacebookInstantGamesIdAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementLinkFacebookInstantGamesIdRequest *")] PFAccountManagementLinkFacebookInstantGamesIdRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkGameCenterAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementLinkGameCenterAccountRequest *")] PFAccountManagementLinkGameCenterAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkGoogleAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementLinkGoogleAccountRequest *")] PFAccountManagementLinkGoogleAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkGooglePlayGamesServicesAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementLinkGooglePlayGamesServicesAccountRequest *")] PFAccountManagementLinkGooglePlayGamesServicesAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkIOSDeviceIDAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementLinkIOSDeviceIDRequest *")] PFAccountManagementLinkIOSDeviceIDRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkKongregateAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementLinkKongregateAccountRequest *")] PFAccountManagementLinkKongregateAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkNintendoServiceAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementClientLinkNintendoServiceAccountRequest *")] PFAccountManagementClientLinkNintendoServiceAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkNintendoSwitchDeviceIdAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementClientLinkNintendoSwitchDeviceIdRequest *")] PFAccountManagementClientLinkNintendoSwitchDeviceIdRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkOpenIdConnectAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementLinkOpenIdConnectRequest *")] PFAccountManagementLinkOpenIdConnectRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkPSNAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementClientLinkPSNAccountRequest *")] PFAccountManagementClientLinkPSNAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkSteamAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementLinkSteamAccountRequest *")] PFAccountManagementLinkSteamAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkTwitchAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementClientLinkTwitchAccountRequest *")] PFAccountManagementClientLinkTwitchAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientLinkXboxAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementClientLinkXboxAccountRequest *")] PFAccountManagementClientLinkXboxAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientRemoveContactEmailAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementRemoveContactEmailRequest *")] PFAccountManagementRemoveContactEmailRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientReportPlayerAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementReportPlayerClientRequest *")] PFAccountManagementReportPlayerClientRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientReportPlayerGetResult(XAsyncBlock* async, PFAccountManagementReportPlayerClientResult* result);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientSendAccountRecoveryEmailAsync([NativeTypeName("PFServiceConfigHandle")] IntPtr serviceConfigHandle, [NativeTypeName("const PFAccountManagementSendAccountRecoveryEmailRequest *")] PFAccountManagementSendAccountRecoveryEmailRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkAndroidDeviceIDAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementUnlinkAndroidDeviceIDRequest *")] PFAccountManagementUnlinkAndroidDeviceIDRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkAppleAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementUnlinkAppleRequest *")] PFAccountManagementUnlinkAppleRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkBattleNetAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementClientUnlinkBattleNetAccountRequest *")] PFAccountManagementClientUnlinkBattleNetAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkCustomIDAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementUnlinkCustomIDRequest *")] PFAccountManagementUnlinkCustomIDRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkFacebookAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementClientUnlinkFacebookAccountRequest *")] PFAccountManagementClientUnlinkFacebookAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkFacebookInstantGamesIdAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementClientUnlinkFacebookInstantGamesIdRequest *")] PFAccountManagementClientUnlinkFacebookInstantGamesIdRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkGameCenterAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementUnlinkGameCenterAccountRequest *")] PFAccountManagementUnlinkGameCenterAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkGoogleAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementUnlinkGoogleAccountRequest *")] PFAccountManagementUnlinkGoogleAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkGooglePlayGamesServicesAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementUnlinkGooglePlayGamesServicesAccountRequest *")] PFAccountManagementUnlinkGooglePlayGamesServicesAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkIOSDeviceIDAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementUnlinkIOSDeviceIDRequest *")] PFAccountManagementUnlinkIOSDeviceIDRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkKongregateAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementUnlinkKongregateAccountRequest *")] PFAccountManagementUnlinkKongregateAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkNintendoServiceAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementClientUnlinkNintendoServiceAccountRequest *")] PFAccountManagementClientUnlinkNintendoServiceAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkNintendoSwitchDeviceIdAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementClientUnlinkNintendoSwitchDeviceIdRequest *")] PFAccountManagementClientUnlinkNintendoSwitchDeviceIdRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkOpenIdConnectAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementUnlinkOpenIdConnectRequest *")] PFAccountManagementUnlinkOpenIdConnectRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkPSNAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementClientUnlinkPSNAccountRequest *")] PFAccountManagementClientUnlinkPSNAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkSteamAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementUnlinkSteamAccountRequest *")] PFAccountManagementUnlinkSteamAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkTwitchAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementClientUnlinkTwitchAccountRequest *")] PFAccountManagementClientUnlinkTwitchAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUnlinkXboxAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementClientUnlinkXboxAccountRequest *")] PFAccountManagementClientUnlinkXboxAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUpdateAvatarUrlAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementClientUpdateAvatarUrlRequest *")] PFAccountManagementClientUpdateAvatarUrlRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUpdateUserTitleDisplayNameAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementUpdateUserTitleDisplayNameRequest *")] PFAccountManagementUpdateUserTitleDisplayNameRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUpdateUserTitleDisplayNameGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementClientUpdateUserTitleDisplayNameGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementUpdateUserTitleDisplayNameResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerBanUsersAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementBanUsersRequest *")] PFAccountManagementBanUsersRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerBanUsersGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerBanUsersGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementBanUsersResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerDeletePlayerAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementDeletePlayerRequest *")] PFAccountManagementDeletePlayerRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayerCombinedInfoAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementGetPlayerCombinedInfoRequest *")] PFAccountManagementGetPlayerCombinedInfoRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayerCombinedInfoGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayerCombinedInfoGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayerCombinedInfoResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayerProfileAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementGetPlayerProfileRequest *")] PFAccountManagementGetPlayerProfileRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayerProfileGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayerProfileGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayerProfileResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromBattleNetAccountIdsAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest *")] PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromBattleNetAccountIdsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromBattleNetAccountIdsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromFacebookIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest *")] PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromFacebookIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromFacebookIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromFacebookIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromFacebookInstantGamesIdsAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest *")] PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromFacebookInstantGamesIdsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromFacebookInstantGamesIdsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromNintendoServiceAccountIdsAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest *")] PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromNintendoServiceAccountIdsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromNintendoServiceAccountIdsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromNintendoSwitchDeviceIdsAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest *")] PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromNintendoSwitchDeviceIdsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromNintendoSwitchDeviceIdsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromPSNAccountIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest *")] PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromPSNAccountIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromPSNAccountIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromPSNOnlineIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest *")] PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromPSNOnlineIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromPSNOnlineIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromSteamIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromSteamIDsRequest *")] PFAccountManagementGetPlayFabIDsFromSteamIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromSteamIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromSteamIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromSteamIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromSteamNamesAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromSteamNamesRequest *")] PFAccountManagementGetPlayFabIDsFromSteamNamesRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromSteamNamesGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromSteamNamesGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromSteamNamesResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromTwitchIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest *")] PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromTwitchIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromTwitchIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromTwitchIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromXboxLiveIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest *")] PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromXboxLiveIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetPlayFabIDsFromXboxLiveIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetServerCustomIDsFromPlayFabIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementGetServerCustomIDsFromPlayFabIDsRequest *")] PFAccountManagementGetServerCustomIDsFromPlayFabIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetServerCustomIDsFromPlayFabIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetServerCustomIDsFromPlayFabIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetServerCustomIDsFromPlayFabIDsResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetUserAccountInfoAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementGetUserAccountInfoRequest *")] PFAccountManagementGetUserAccountInfoRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetUserAccountInfoGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetUserAccountInfoGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetUserAccountInfoResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetUserBansAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementGetUserBansRequest *")] PFAccountManagementGetUserBansRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetUserBansGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerGetUserBansGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetUserBansResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerLinkBattleNetAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementServerLinkBattleNetAccountRequest *")] PFAccountManagementServerLinkBattleNetAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerLinkNintendoServiceAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementServerLinkNintendoServiceAccountRequest *")] PFAccountManagementServerLinkNintendoServiceAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerLinkNintendoServiceAccountSubjectAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementLinkNintendoServiceAccountSubjectRequest *")] PFAccountManagementLinkNintendoServiceAccountSubjectRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerLinkNintendoSwitchDeviceIdAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementServerLinkNintendoSwitchDeviceIdRequest *")] PFAccountManagementServerLinkNintendoSwitchDeviceIdRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerLinkPSNAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementServerLinkPSNAccountRequest *")] PFAccountManagementServerLinkPSNAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerLinkPSNIdAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementLinkPSNIdRequest *")] PFAccountManagementLinkPSNIdRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerLinkServerCustomIdAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementLinkServerCustomIdRequest *")] PFAccountManagementLinkServerCustomIdRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerLinkSteamIdAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementLinkSteamIdRequest *")] PFAccountManagementLinkSteamIdRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerLinkXboxAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementServerLinkXboxAccountRequest *")] PFAccountManagementServerLinkXboxAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerRevokeAllBansForUserAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementRevokeAllBansForUserRequest *")] PFAccountManagementRevokeAllBansForUserRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerRevokeAllBansForUserGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerRevokeAllBansForUserGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementRevokeAllBansForUserResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerRevokeBansAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementRevokeBansRequest *")] PFAccountManagementRevokeBansRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerRevokeBansGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerRevokeBansGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementRevokeBansResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerSendCustomAccountRecoveryEmailAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementSendCustomAccountRecoveryEmailRequest *")] PFAccountManagementSendCustomAccountRecoveryEmailRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerSendEmailFromTemplateAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementSendEmailFromTemplateRequest *")] PFAccountManagementSendEmailFromTemplateRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerUnlinkBattleNetAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementServerUnlinkBattleNetAccountRequest *")] PFAccountManagementServerUnlinkBattleNetAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerUnlinkNintendoServiceAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementServerUnlinkNintendoServiceAccountRequest *")] PFAccountManagementServerUnlinkNintendoServiceAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerUnlinkNintendoSwitchDeviceIdAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementServerUnlinkNintendoSwitchDeviceIdRequest *")] PFAccountManagementServerUnlinkNintendoSwitchDeviceIdRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerUnlinkPSNAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementServerUnlinkPSNAccountRequest *")] PFAccountManagementServerUnlinkPSNAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerUnlinkServerCustomIdAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementUnlinkServerCustomIdRequest *")] PFAccountManagementUnlinkServerCustomIdRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerUnlinkSteamIdAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementUnlinkSteamIdRequest *")] PFAccountManagementUnlinkSteamIdRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerUnlinkXboxAccountAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementServerUnlinkXboxAccountRequest *")] PFAccountManagementServerUnlinkXboxAccountRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerUpdateAvatarUrlAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementServerUpdateAvatarUrlRequest *")] PFAccountManagementServerUpdateAvatarUrlRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerUpdateBansAsync([NativeTypeName("PFEntityHandle")] IntPtr titleEntityHandle, [NativeTypeName("const PFAccountManagementUpdateBansRequest *")] PFAccountManagementUpdateBansRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerUpdateBansGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementServerUpdateBansGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementUpdateBansResult** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementGetTitlePlayersFromXboxLiveIDsAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementGetTitlePlayersFromXboxLiveIDsRequest *")] PFAccountManagementGetTitlePlayersFromXboxLiveIDsRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementGetTitlePlayersFromXboxLiveIDsGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementGetTitlePlayersFromXboxLiveIDsGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementGetTitlePlayersFromProviderIDsResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementSetDisplayNameAsync([NativeTypeName("PFEntityHandle")] IntPtr entityHandle, [NativeTypeName("const PFAccountManagementSetDisplayNameRequest *")] PFAccountManagementSetDisplayNameRequest* request, XAsyncBlock* async);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementSetDisplayNameGetResultSize(XAsyncBlock* async, [NativeTypeName("size_t *")] ulong* bufferSize);

        [DllImport(PlayFabServicesLibName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int PFAccountManagementSetDisplayNameGetResult(XAsyncBlock* async, [NativeTypeName("size_t")] ulong bufferSize, void* buffer, PFAccountManagementSetDisplayNameResponse** result, [NativeTypeName("size_t *")] ulong* bufferUsed);
    }
}
