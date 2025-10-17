namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromSteamNamesResult
    {
        [NativeTypeName("const PFAccountManagementSteamNamePlayFabIdPair *const *")]
        public PFAccountManagementSteamNamePlayFabIdPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
