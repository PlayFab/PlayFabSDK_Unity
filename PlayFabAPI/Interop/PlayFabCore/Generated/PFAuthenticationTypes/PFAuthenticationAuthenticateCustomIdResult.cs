namespace PlayFab.Interop
{
    public unsafe partial struct PFAuthenticationAuthenticateCustomIdResult
    {
        [NativeTypeName("const PFAuthenticationEntityTokenResponse *")]
        public PFAuthenticationEntityTokenResponse* entityToken;

        public byte newlyCreated;
    }
}
