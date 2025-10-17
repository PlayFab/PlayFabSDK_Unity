namespace PlayFab.Interop
{
    public unsafe partial struct PFAuthenticationLoginWithOpenIdConnectRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* connectionId;

        public byte createAccount;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* idToken;

        [NativeTypeName("const PFGetPlayerCombinedInfoRequestParams *")]
        public PFGetPlayerCombinedInfoRequestParams* infoRequestParameters;

        [NativeTypeName("const char *")]
        public sbyte* playerSecret;
    }
}
