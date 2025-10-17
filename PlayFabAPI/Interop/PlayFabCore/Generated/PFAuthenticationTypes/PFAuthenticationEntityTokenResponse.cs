namespace PlayFab.Interop
{
    public unsafe partial struct PFAuthenticationEntityTokenResponse
    {
        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const char *")]
        public sbyte* entityToken;

        [NativeTypeName("const time_t *")]
        public long* tokenExpiration;
    }
}
