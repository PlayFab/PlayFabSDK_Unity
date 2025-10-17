namespace PlayFab.Interop
{
    public unsafe partial struct PFUserGooglePlayGamesInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* googlePlayGamesPlayerAvatarImageUrl;

        [NativeTypeName("const char *")]
        public sbyte* googlePlayGamesPlayerDisplayName;

        [NativeTypeName("const char *")]
        public sbyte* googlePlayGamesPlayerId;
    }
}
