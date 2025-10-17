namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromGoogleIDsResult
    {
        [NativeTypeName("const PFAccountManagementGooglePlayFabIdPair *const *")]
        public PFAccountManagementGooglePlayFabIdPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
