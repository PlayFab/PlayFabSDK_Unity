namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogReportItemReviewRequest
    {
        [NativeTypeName("const PFCatalogCatalogAlternateId *")]
        public PFCatalogCatalogAlternateId* alternateId;

        [NativeTypeName("const PFCatalogConcernCategory *")]
        public PFCatalogConcernCategory* concernCategory;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const char *")]
        public sbyte* itemId;

        [NativeTypeName("const char *")]
        public sbyte* reason;

        [NativeTypeName("const char *")]
        public sbyte* reviewId;
    }
}
