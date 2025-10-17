namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogSearchItemsRequest
    {
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
        public sbyte* filter;

        [NativeTypeName("const char *")]
        public sbyte* language;

        [NativeTypeName("const char *")]
        public sbyte* orderBy;

        [NativeTypeName("const char *")]
        public sbyte* search;

        [NativeTypeName("const char *")]
        public sbyte* select;

        [NativeTypeName("const PFCatalogStoreReference *")]
        public PFCatalogStoreReference* store;
    }
}
