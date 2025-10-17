namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogCatalogPriceAmountOverride
    {
        [NativeTypeName("const int32_t *")]
        public int* fixedValue;

        [NativeTypeName("const char *")]
        public sbyte* itemId;

        [NativeTypeName("const double *")]
        public double* multiplier;
    }
}
