namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryAddInventoryItemsOperation
    {
        [NativeTypeName("const int32_t *")]
        public int* amount;

        [NativeTypeName("const double *")]
        public double* durationInSeconds;

        [NativeTypeName("const PFInventoryInventoryItemReference *")]
        public PFInventoryInventoryItemReference* item;

        [NativeTypeName("const PFInventoryInitialValues *")]
        public PFInventoryInitialValues* newStackValues;
    }
}
