namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogCatalogPriceOptionsOverride
    {
        [NativeTypeName("const PFCatalogCatalogPriceOverride *const *")]
        public PFCatalogCatalogPriceOverride** prices;

        [NativeTypeName("uint32_t")]
        public uint pricesCount;
    }
}
