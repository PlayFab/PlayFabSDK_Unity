namespace PlayFab.Interop.Multiplayer
{
    public static unsafe partial class Methods
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN || MICROSOFT_GDK_SUPPORT || MICROSOFT_GAME_CORE || UNITY_GAMECORE
        private const string PlayFabMultiplayerLibName = "PlayFabMultiplayerGDK";
#else
        private const string PlayFabMultiplayerLibName = "Unsupported Platform";
#endif
    }
}