namespace PlayFab.Interop
{
    public unsafe partial struct PFAuthenticationLoginWithPlayFabRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFGetPlayerCombinedInfoRequestParams *")]
        public PFGetPlayerCombinedInfoRequestParams* infoRequestParameters;

        [NativeTypeName("const char *")]
        public sbyte* password;

        [NativeTypeName("const char *")]
        public sbyte* username;
    }
}
