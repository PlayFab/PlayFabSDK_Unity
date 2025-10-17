namespace PlayFab.Interop
{
    public unsafe partial struct PFInventorySubtractInventoryItemsOperation
    {
        [NativeTypeName("const int32_t *")]
        public int* amount;

        public byte deleteEmptyStacks;

        [NativeTypeName("const double *")]
        public double* durationInSeconds;

        [NativeTypeName("const PFInventoryInventoryItemReference *")]
        public PFInventoryInventoryItemReference* item;
    }
}
