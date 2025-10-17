namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromFacebookIDsResult
    {
        [NativeTypeName("const PFAccountManagementFacebookPlayFabIdPair *const *")]
        public PFAccountManagementFacebookPlayFabIdPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
