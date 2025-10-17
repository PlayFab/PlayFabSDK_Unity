namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogGetItemReviewSummaryResponse
    {
        [NativeTypeName("const PFCatalogReview *")]
        public PFCatalogReview* leastFavorableReview;

        [NativeTypeName("const PFCatalogReview *")]
        public PFCatalogReview* mostFavorableReview;

        [NativeTypeName("const PFCatalogRating *")]
        public PFCatalogRating* rating;

        [NativeTypeName("int32_t")]
        public int reviewsCount;
    }
}
