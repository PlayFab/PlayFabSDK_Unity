namespace PlayFab.Interop
{
    public unsafe partial struct PFAuthenticationLoginWithGameCenterRequest
    {
        public byte createAccount;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFGetPlayerCombinedInfoRequestParams *")]
        public PFGetPlayerCombinedInfoRequestParams* infoRequestParameters;

        [NativeTypeName("const char *")]
        public sbyte* playerId;

        [NativeTypeName("const char *")]
        public sbyte* playerSecret;

        [NativeTypeName("const char *")]
        public sbyte* publicKeyUrl;

        [NativeTypeName("const char *")]
        public sbyte* salt;

        [NativeTypeName("const char *")]
        public sbyte* signature;

        [NativeTypeName("const char *")]
        public sbyte* timestamp;
    }
}
