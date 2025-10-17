namespace PlayFab.Interop
{
    public unsafe partial struct PFAuthenticationServerLoginWithAndroidDeviceIDRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* androidDevice;

        [NativeTypeName("const char *")]
        public sbyte* androidDeviceId;

        public byte createAccount;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFGetPlayerCombinedInfoRequestParams *")]
        public PFGetPlayerCombinedInfoRequestParams* infoRequestParameters;

        [NativeTypeName("const char *")]
        public sbyte* OS;
    }
}
