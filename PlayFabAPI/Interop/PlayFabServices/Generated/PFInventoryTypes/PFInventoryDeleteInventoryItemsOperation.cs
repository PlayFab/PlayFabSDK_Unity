namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryDeleteInventoryItemsOperation
    {
        [NativeTypeName("const PFInventoryInventoryItemReference *")]
        public PFInventoryInventoryItemReference* item;
    }
}
