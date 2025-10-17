namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogReviewConfig
    {
        [NativeTypeName("const PFCatalogCategoryRatingConfig *const *")]
        public PFCatalogCategoryRatingConfig** categoryRatings;

        [NativeTypeName("uint32_t")]
        public uint categoryRatingsCount;
    }
}
