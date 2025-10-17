namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogReviewTakedown
    {
        [NativeTypeName("const PFCatalogCatalogAlternateId *")]
        public PFCatalogCatalogAlternateId* alternateId;

        [NativeTypeName("const char *")]
        public sbyte* itemId;

        [NativeTypeName("const char *")]
        public sbyte* reviewId;
    }
}
