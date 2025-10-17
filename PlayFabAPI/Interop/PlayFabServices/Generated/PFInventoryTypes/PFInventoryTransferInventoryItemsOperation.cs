namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryTransferInventoryItemsOperation
    {
        [NativeTypeName("const int32_t *")]
        public int* amount;

        public byte deleteEmptyStacks;

        [NativeTypeName("const PFInventoryInventoryItemReference *")]
        public PFInventoryInventoryItemReference* givingItem;

        [NativeTypeName("const PFInventoryInitialValues *")]
        public PFInventoryInitialValues* newStackValues;

        [NativeTypeName("const PFInventoryInventoryItemReference *")]
        public PFInventoryInventoryItemReference* receivingItem;
    }
}
