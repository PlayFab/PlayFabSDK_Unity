namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogGetItemReviewsResponse
    {
        [NativeTypeName("const char *")]
        public sbyte* continuationToken;

        [NativeTypeName("const PFCatalogReview *const *")]
        public PFCatalogReview** reviews;

        [NativeTypeName("uint32_t")]
        public uint reviewsCount;
    }
}
