#if UNITY_STANDALONE_WIN || MICROSOFT_GDK_SUPPORT
namespace PlayFab.Tools
{
    /// <summary>
    /// Constants shared between GDK utility classes
    /// </summary>
    public static class GdkConstants
    {
        /// <summary>
        /// Target plugin path for GDK binaries
        /// </summary>
        public const string TargetGdkPluginPath = "Assets/Plugins/GDK";
        
        /// <summary>
        /// GDK edition JSON file name
        /// </summary>
        public const string GdkEditionJsonFileName = "GdkEdition.json";
        
        /// <summary>
        /// List of required GDK binaries that need to be copied and configured
        /// </summary>
        public static readonly string[] RequiredGdkBinaries = new string[]
        {
            "libHttpClient.dll",
            "Party.dll",
            "PlayFabCore.dll",
            "PlayFabGameSave.dll",
            "PlayFabMultiplayer.dll",
            "PlayFabServices.dll",
            "XCurl.dll",
            "XGameRuntime.Thunks.dll",
            "xgameruntime.dll"
        };
    }
}
#endif
