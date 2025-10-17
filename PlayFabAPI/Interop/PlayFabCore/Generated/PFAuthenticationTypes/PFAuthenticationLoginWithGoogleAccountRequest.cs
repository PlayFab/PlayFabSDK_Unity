namespace PlayFab.Interop
{
    public unsafe partial struct PFAuthenticationLoginWithGoogleAccountRequest
    {
        public byte createAccount;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFGetPlayerCombinedInfoRequestParams *")]
        public PFGetPlayerCombinedInfoRequestParams* infoRequestParameters;

        [NativeTypeName("const char *")]
        public sbyte* playerSecret;

        [NativeTypeName("const char *")]
        public sbyte* serverAuthCode;

        [NativeTypeName("const bool *")]
        public byte* setEmail;
    }
}
