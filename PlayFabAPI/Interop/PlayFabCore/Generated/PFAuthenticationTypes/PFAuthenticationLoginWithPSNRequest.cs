namespace PlayFab.Interop
{
    public unsafe partial struct PFAuthenticationLoginWithPSNRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* authCode;

        public byte createAccount;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFGetPlayerCombinedInfoRequestParams *")]
        public PFGetPlayerCombinedInfoRequestParams* infoRequestParameters;

        [NativeTypeName("const int32_t *")]
        public int* issuerId;

        [NativeTypeName("const char *")]
        public sbyte* playerSecret;

        [NativeTypeName("const char *")]
        public sbyte* redirectUri;
    }
}
