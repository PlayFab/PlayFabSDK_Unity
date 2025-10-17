namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogGetItemContainersRequest
    {
        [NativeTypeName("const PFCatalogCatalogAlternateId *")]
        public PFCatalogCatalogAlternateId* alternateId;

        [NativeTypeName("const char *")]
        public sbyte* continuationToken;

        [NativeTypeName("int32_t")]
        public int count;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const char *")]
        public sbyte* id;
    }
}
