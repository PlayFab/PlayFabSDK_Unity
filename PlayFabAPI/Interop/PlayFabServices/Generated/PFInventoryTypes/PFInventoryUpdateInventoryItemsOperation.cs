namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryUpdateInventoryItemsOperation
    {
        [NativeTypeName("const PFInventoryInventoryItem *")]
        public PFInventoryInventoryItem* item;
    }
}
