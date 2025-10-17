namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryTransferInventoryItemsRequest
    {
        [NativeTypeName("const int32_t *")]
        public int* amount;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        public byte deleteEmptyStacks;

        [NativeTypeName("const char *")]
        public sbyte* givingCollectionId;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* givingEntity;

        [NativeTypeName("const char *")]
        public sbyte* givingETag;

        [NativeTypeName("const PFInventoryInventoryItemReference *")]
        public PFInventoryInventoryItemReference* givingItem;

        [NativeTypeName("const char *")]
        public sbyte* idempotencyId;

        [NativeTypeName("const PFInventoryInitialValues *")]
        public PFInventoryInitialValues* newStackValues;

        [NativeTypeName("const char *")]
        public sbyte* receivingCollectionId;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* receivingEntity;

        [NativeTypeName("const PFInventoryInventoryItemReference *")]
        public PFInventoryInventoryItemReference* receivingItem;
    }
}
