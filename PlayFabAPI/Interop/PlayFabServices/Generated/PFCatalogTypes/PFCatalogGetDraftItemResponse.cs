namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogGetDraftItemResponse
    {
        [NativeTypeName("const PFCatalogCatalogItem *")]
        public PFCatalogCatalogItem* item;
    }
}
