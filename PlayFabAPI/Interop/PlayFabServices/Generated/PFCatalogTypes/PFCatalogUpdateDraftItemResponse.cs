namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogUpdateDraftItemResponse
    {
        [NativeTypeName("const PFCatalogCatalogItem *")]
        public PFCatalogCatalogItem* item;
    }
}
