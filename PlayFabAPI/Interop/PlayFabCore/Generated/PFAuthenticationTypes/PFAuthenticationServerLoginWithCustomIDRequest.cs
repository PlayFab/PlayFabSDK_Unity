namespace PlayFab.Interop
{
    public unsafe partial struct PFAuthenticationServerLoginWithCustomIDRequest
    {
        public byte createAccount;

        [NativeTypeName("const char *")]
        public sbyte* customId;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFGetPlayerCombinedInfoRequestParams *")]
        public PFGetPlayerCombinedInfoRequestParams* infoRequestParameters;
    }
}
