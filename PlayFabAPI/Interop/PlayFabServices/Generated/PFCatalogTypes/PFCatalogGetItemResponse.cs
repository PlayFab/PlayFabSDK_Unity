namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogGetItemResponse
    {
        [NativeTypeName("const PFCatalogCatalogItem *")]
        public PFCatalogCatalogItem* item;
    }
}
