namespace PlayFab.Interop
{
    public unsafe partial struct PFAuthenticationValidateEntityTokenResponse
    {
        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const PFAuthenticationIdentifiedDeviceType *")]
        public PFAuthenticationIdentifiedDeviceType* identifiedDeviceType;

        [NativeTypeName("const PFLoginIdentityProvider *")]
        public PFLoginIdentityProvider* identityProvider;

        [NativeTypeName("const char *")]
        public sbyte* identityProviderIssuedId;

        [NativeTypeName("const PFEntityLineage *")]
        public PFEntityLineage* lineage;
    }
}
