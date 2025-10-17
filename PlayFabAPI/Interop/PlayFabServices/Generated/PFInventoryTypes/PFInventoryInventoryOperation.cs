namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryInventoryOperation
    {
        [NativeTypeName("const PFInventoryAddInventoryItemsOperation *")]
        public PFInventoryAddInventoryItemsOperation* add;

        [NativeTypeName("const PFInventoryDeleteInventoryItemsOperation *")]
        public PFInventoryDeleteInventoryItemsOperation* deleteOp;

        [NativeTypeName("const PFInventoryPurchaseInventoryItemsOperation *")]
        public PFInventoryPurchaseInventoryItemsOperation* purchase;

        [NativeTypeName("const PFInventorySubtractInventoryItemsOperation *")]
        public PFInventorySubtractInventoryItemsOperation* subtract;

        [NativeTypeName("const PFInventoryTransferInventoryItemsOperation *")]
        public PFInventoryTransferInventoryItemsOperation* transfer;

        [NativeTypeName("const PFInventoryUpdateInventoryItemsOperation *")]
        public PFInventoryUpdateInventoryItemsOperation* update;
    }
}
