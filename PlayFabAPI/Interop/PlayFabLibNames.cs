namespace PlayFab.Interop
{
    public static unsafe partial class Methods
    {
        private const string XGameRuntimeLibName = "XGameRuntime.Thunks";
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT
        private const string LibHttpClientLibName = "libHttpClient.GDK";
        private const string PlayFabCoreLibName = "PlayFabCore.GDK";
        private const string PlayFabServicesLibName = "PlayFabServices.GDK";
        private const string PlayFabGameSaveLibName = "PlayFabGameSave.GDK";
#elif UNITY_STANDALONE_LINUX || UNITY_EDITOR_LINUX
        private const string LibHttpClientLibName = "libHttpClient.Linux.so";
        private const string PlayFabCoreLibName = "PlayFabCore.Linux.so";
        private const string PlayFabServicesLibName = "PlayFabServices.Linux.so";
        private const string PlayFabGameSaveLibName = "PlayFabGameSave.Linux.so";
#elif UNITY_STANDALONE_OSX || UNITY_EDITOR_OSX
        private const string LibHttpClientLibName = "HttpClient.framework/HttpClient";
        private const string PlayFabCoreLibName = "PlayFabCore_macOS.framework/PlayFabCore_macOS";
        private const string PlayFabServicesLibName = "PlayFabServices_macOS.framework/PlayFabServices_macOS";
        private const string PlayFabGameSaveLibName = "PlayFabGameSave_macOS.framework/PlayFabGameSave_macOS";
#elif UNITY_IOS
        private const string LibHttpClientLibName = "HttpClient.framework/HttpClient";
        private const string PlayFabCoreLibName = "PlayFabCore_iOS.framework/PlayFabCore_iOS";
        private const string PlayFabServicesLibName = "PlayFabServices_iOS.framework/PlayFabServices_iOS";
        private const string PlayFabGameSaveLibName = "PlayFabGameSave_iOS.framework/PlayFabGameSave_iOS";
#elif UNITY_ANDROID
        private const string LibHttpClientLibName = "libHttpClient.Android.so";
        private const string PlayFabCoreLibName = "libPlayFabCore.Android.so";
        private const string PlayFabServicesLibName = "libPlayFabServices.Android.so";
        private const string PlayFabGameSaveLibName = "libPlayFabGameSave.Android.so";
#elif UNITY_SWITCH || UNITY_OUNCE || UNITY_SWITCH2
        private const string LibHttpClientLibName = "libHttpClient.Switch";
        private const string PlayFabCoreLibName = "PlayFabCore.Switch";
        private const string PlayFabServicesLibName = "PlayFabServices.Switch";
        private const string PlayFabGameSaveLibName = "PlayFabGameSave.Switch";
#elif UNITY_PS4 || UNITY_PS5
        private const string LibHttpClientLibName = "libHttpClient.prx";
        private const string PlayFabCoreLibName = "PlayFabCore.PS.prx";
        private const string PlayFabServicesLibName = "PlayFabServices.PS.prx";
        private const string PlayFabGameSaveLibName = "PlayFabGameSave.PS.prx";
#else
        private const string LibHttpClientLibName = "Unsupported Platform";
        private const string PlayFabCoreLibName = "Unsupported Platform";
        private const string PlayFabServicesLibName = "Unsupported Platform";
        private const string PlayFabGameSaveLibName = "Unsupported Platform";
#endif
    }
}