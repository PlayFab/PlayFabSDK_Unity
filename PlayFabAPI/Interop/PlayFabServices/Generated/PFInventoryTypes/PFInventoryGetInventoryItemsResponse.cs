namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryGetInventoryItemsResponse
    {
        [NativeTypeName("const char *")]
        public sbyte* continuationToken;

        [NativeTypeName("const char *")]
        public sbyte* eTag;

        [NativeTypeName("const PFInventoryInventoryItem *const *")]
        public PFInventoryInventoryItem** items;

        [NativeTypeName("uint32_t")]
        public uint itemsCount;
    }
}
