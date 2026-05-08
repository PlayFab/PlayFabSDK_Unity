namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromOpenIdsResult
    {
        [NativeTypeName("const PFAccountManagementOpenIdSubjectIdentifierPlayFabIdPair *const *")]
        public PFAccountManagementOpenIdSubjectIdentifierPlayFabIdPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
