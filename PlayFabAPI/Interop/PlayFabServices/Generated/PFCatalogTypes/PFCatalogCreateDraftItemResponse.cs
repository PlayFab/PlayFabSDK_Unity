namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogCreateDraftItemResponse
    {
        [NativeTypeName("const PFCatalogCatalogItem *")]
        public PFCatalogCatalogItem* item;
    }
}
