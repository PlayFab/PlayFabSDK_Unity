namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromGooglePlayGamesPlayerIDsResult
    {
        [NativeTypeName("const PFAccountManagementGooglePlayGamesPlayFabIdPair *const *")]
        public PFAccountManagementGooglePlayGamesPlayFabIdPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
