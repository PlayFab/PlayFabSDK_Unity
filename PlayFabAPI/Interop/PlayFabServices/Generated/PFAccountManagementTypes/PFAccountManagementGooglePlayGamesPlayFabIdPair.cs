namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGooglePlayGamesPlayFabIdPair
    {
        [NativeTypeName("const char *")]
        public sbyte* googlePlayGamesPlayerId;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
