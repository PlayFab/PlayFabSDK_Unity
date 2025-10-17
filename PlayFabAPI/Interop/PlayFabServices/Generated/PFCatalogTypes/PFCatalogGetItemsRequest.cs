namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogGetItemsRequest
    {
        [NativeTypeName("const PFCatalogCatalogAlternateId *const *")]
        public PFCatalogCatalogAlternateId** alternateIds;

        [NativeTypeName("uint32_t")]
        public uint alternateIdsCount;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const char *const *")]
        public sbyte** ids;

        [NativeTypeName("uint32_t")]
        public uint idsCount;
    }
}
