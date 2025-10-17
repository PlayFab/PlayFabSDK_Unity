namespace PlayFab.Interop
{
    public unsafe partial struct PFAuthenticationServerLoginWithIOSDeviceIDRequest
    {
        public byte createAccount;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* deviceId;

        [NativeTypeName("const char *")]
        public sbyte* deviceModel;

        [NativeTypeName("const PFGetPlayerCombinedInfoRequestParams *")]
        public PFGetPlayerCombinedInfoRequestParams* infoRequestParameters;

        [NativeTypeName("const char *")]
        public sbyte* OS;
    }
}
