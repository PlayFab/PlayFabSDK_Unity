namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromSteamIDsResult
    {
        [NativeTypeName("const PFAccountManagementSteamPlayFabIdPair *const *")]
        public PFAccountManagementSteamPlayFabIdPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
