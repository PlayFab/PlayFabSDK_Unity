namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogGetEntityItemReviewResponse
    {
        [NativeTypeName("const PFCatalogReview *")]
        public PFCatalogReview* review;
    }
}
