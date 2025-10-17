namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementLinkFacebookAccountRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* accessToken;

        [NativeTypeName("const char *")]
        public sbyte* authenticationToken;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const bool *")]
        public byte* forceLink;
    }
}
