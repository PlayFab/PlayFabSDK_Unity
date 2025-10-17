namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogCatalogPriceOverride
    {
        [NativeTypeName("const PFCatalogCatalogPriceAmountOverride *const *")]
        public PFCatalogCatalogPriceAmountOverride** amounts;

        [NativeTypeName("uint32_t")]
        public uint amountsCount;
    }
}
