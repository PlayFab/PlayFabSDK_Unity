namespace PlayFab.Interop
{
    public unsafe partial struct PFAuthenticationLoginWithKongregateRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* authTicket;

        public byte createAccount;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFGetPlayerCombinedInfoRequestParams *")]
        public PFGetPlayerCombinedInfoRequestParams* infoRequestParameters;

        [NativeTypeName("const char *")]
        public sbyte* kongregateId;

        [NativeTypeName("const char *")]
        public sbyte* playerSecret;
    }
}
