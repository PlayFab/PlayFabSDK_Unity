namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementLinkOpenIdConnectRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* connectionId;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const bool *")]
        public byte* forceLink;

        [NativeTypeName("const char *")]
        public sbyte* idToken;
    }
}
