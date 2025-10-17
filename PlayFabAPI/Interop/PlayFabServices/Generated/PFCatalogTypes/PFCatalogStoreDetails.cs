namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogStoreDetails
    {
        [NativeTypeName("const PFCatalogFilterOptions *")]
        public PFCatalogFilterOptions* filterOptions;

        [NativeTypeName("const PFCatalogPermissions *")]
        public PFCatalogPermissions* permissions;

        [NativeTypeName("const PFCatalogCatalogPriceOptionsOverride *")]
        public PFCatalogCatalogPriceOptionsOverride* priceOptionsOverride;
    }
}
