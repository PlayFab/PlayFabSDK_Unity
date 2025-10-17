namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogGetEntityDraftItemsResponse
    {
        [NativeTypeName("const char *")]
        public sbyte* continuationToken;

        [NativeTypeName("const PFCatalogCatalogItem *const *")]
        public PFCatalogCatalogItem** items;

        [NativeTypeName("uint32_t")]
        public uint itemsCount;
    }
}
