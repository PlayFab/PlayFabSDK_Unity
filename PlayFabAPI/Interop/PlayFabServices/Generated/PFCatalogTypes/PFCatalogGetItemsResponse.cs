namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogGetItemsResponse
    {
        [NativeTypeName("const PFCatalogCatalogItem *const *")]
        public PFCatalogCatalogItem** items;

        [NativeTypeName("uint32_t")]
        public uint itemsCount;
    }
}
