namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryPurchaseInventoryItemsOperation
    {
        [NativeTypeName("const int32_t *")]
        public int* amount;

        public byte deleteEmptyStacks;

        [NativeTypeName("const double *")]
        public double* durationInSeconds;

        [NativeTypeName("const PFInventoryInventoryItemReference *")]
        public PFInventoryInventoryItemReference* item;

        [NativeTypeName("const PFInventoryInitialValues *")]
        public PFInventoryInitialValues* newStackValues;

        [NativeTypeName("const PFInventoryPurchasePriceAmount *const *")]
        public PFInventoryPurchasePriceAmount** priceAmounts;

        [NativeTypeName("uint32_t")]
        public uint priceAmountsCount;

        [NativeTypeName("const char *")]
        public sbyte* storeId;
    }
}
