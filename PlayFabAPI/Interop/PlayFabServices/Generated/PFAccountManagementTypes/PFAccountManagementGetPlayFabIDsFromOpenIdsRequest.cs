namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromOpenIdsRequest
    {
        [NativeTypeName("const PFAccountManagementOpenIdSubjectIdentifier *const *")]
        public PFAccountManagementOpenIdSubjectIdentifier** openIdSubjectIdentifiers;

        [NativeTypeName("uint32_t")]
        public uint openIdSubjectIdentifiersCount;
    }
}
