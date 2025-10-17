namespace PlayFab.Interop
{
    public unsafe partial struct PFInventorySubtractInventoryItemsRequest
    {
        [NativeTypeName("const int32_t *")]
        public int* amount;

        [NativeTypeName("const char *")]
        public sbyte* collectionId;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        public byte deleteEmptyStacks;

        [NativeTypeName("const double *")]
        public double* durationInSeconds;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const char *")]
        public sbyte* eTag;

        [NativeTypeName("const char *")]
        public sbyte* idempotencyId;

        [NativeTypeName("const PFInventoryInventoryItemReference *")]
        public PFInventoryInventoryItemReference* item;
    }
}
