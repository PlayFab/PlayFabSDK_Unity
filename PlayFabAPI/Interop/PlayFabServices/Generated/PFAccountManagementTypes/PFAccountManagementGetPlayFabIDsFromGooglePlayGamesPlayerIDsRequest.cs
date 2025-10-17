namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** googlePlayGamesPlayerIDs;

        [NativeTypeName("uint32_t")]
        public uint googlePlayGamesPlayerIDsCount;
    }
}
