namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogCatalogPrice
    {
        [NativeTypeName("const PFCatalogCatalogPriceAmount *const *")]
        public PFCatalogCatalogPriceAmount** amounts;

        [NativeTypeName("uint32_t")]
        public uint amountsCount;

        [NativeTypeName("const int32_t *")]
        public int* unitAmount;

        [NativeTypeName("const double *")]
        public double* unitDurationInSeconds;
    }
}
