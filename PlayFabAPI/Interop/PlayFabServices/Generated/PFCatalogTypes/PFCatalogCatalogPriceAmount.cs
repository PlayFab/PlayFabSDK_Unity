namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogCatalogPriceAmount
    {
        [NativeTypeName("int32_t")]
        public int amount;

        [NativeTypeName("const char *")]
        public sbyte* itemId;
    }
}
