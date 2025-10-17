namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementLinkGameCenterAccountRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const bool *")]
        public byte* forceLink;

        [NativeTypeName("const char *")]
        public sbyte* gameCenterId;

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
