namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogTakedownItemReviewsRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFCatalogReviewTakedown *const *")]
        public PFCatalogReviewTakedown** reviews;

        [NativeTypeName("uint32_t")]
        public uint reviewsCount;
    }
}
