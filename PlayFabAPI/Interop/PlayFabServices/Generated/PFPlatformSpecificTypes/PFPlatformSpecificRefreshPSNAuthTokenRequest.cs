namespace PlayFab.Interop
{
    public unsafe partial struct PFPlatformSpecificRefreshPSNAuthTokenRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* authCode;

        [NativeTypeName("const int32_t *")]
        public int* issuerId;

        [NativeTypeName("const char *")]
        public sbyte* redirectUri;
    }
}
