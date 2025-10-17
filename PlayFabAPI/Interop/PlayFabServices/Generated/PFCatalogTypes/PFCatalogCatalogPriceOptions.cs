namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogCatalogPriceOptions
    {
        [NativeTypeName("const PFCatalogCatalogPrice *const *")]
        public PFCatalogCatalogPrice** prices;

        [NativeTypeName("uint32_t")]
        public uint pricesCount;
    }
}
