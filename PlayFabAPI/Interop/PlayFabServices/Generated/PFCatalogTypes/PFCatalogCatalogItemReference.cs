namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogCatalogItemReference
    {
        [NativeTypeName("const int32_t *")]
        public int* amount;

        [NativeTypeName("const char *")]
        public sbyte* id;

        [NativeTypeName("const PFCatalogCatalogPriceOptions *")]
        public PFCatalogCatalogPriceOptions* priceOptions;
    }
}
