namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryExecuteInventoryOperationsRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* collectionId;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const char *")]
        public sbyte* eTag;

        [NativeTypeName("const char *")]
        public sbyte* idempotencyId;

        [NativeTypeName("const PFInventoryInventoryOperation *const *")]
        public PFInventoryInventoryOperation** operations;

        [NativeTypeName("uint32_t")]
        public uint operationsCount;
    }
}
