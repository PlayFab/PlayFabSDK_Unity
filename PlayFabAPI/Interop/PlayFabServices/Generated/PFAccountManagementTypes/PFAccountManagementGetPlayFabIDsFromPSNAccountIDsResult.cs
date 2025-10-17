namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromPSNAccountIDsResult
    {
        [NativeTypeName("const PFAccountManagementPSNAccountPlayFabIdPair *const *")]
        public PFAccountManagementPSNAccountPlayFabIdPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
