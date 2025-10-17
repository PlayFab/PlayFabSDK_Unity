namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryExecuteTransferOperationsRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* givingCollectionId;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* givingEntity;

        [NativeTypeName("const char *")]
        public sbyte* givingETag;

        [NativeTypeName("const char *")]
        public sbyte* idempotencyId;

        [NativeTypeName("const PFInventoryTransferInventoryItemsOperation *const *")]
        public PFInventoryTransferInventoryItemsOperation** operations;

        [NativeTypeName("uint32_t")]
        public uint operationsCount;

        [NativeTypeName("const char *")]
        public sbyte* receivingCollectionId;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* receivingEntity;
    }
}
