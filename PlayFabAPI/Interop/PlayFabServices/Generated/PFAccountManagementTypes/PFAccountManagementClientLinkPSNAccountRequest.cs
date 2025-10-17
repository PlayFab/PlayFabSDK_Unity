namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementClientLinkPSNAccountRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* authCode;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const bool *")]
        public byte* forceLink;

        [NativeTypeName("const int32_t *")]
        public int* issuerId;

        [NativeTypeName("const char *")]
        public sbyte* redirectUri;
    }
}
