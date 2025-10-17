namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsResult
    {
        [NativeTypeName("const PFAccountManagementPSNOnlinePlayFabIdPair *const *")]
        public PFAccountManagementPSNOnlinePlayFabIdPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
