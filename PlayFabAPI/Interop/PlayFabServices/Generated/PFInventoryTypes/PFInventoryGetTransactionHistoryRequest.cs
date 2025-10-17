namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryGetTransactionHistoryRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* collectionId;

        [NativeTypeName("const char *")]
        public sbyte* continuationToken;

        [NativeTypeName("int32_t")]
        public int count;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const char *")]
        public sbyte* filter;

        [NativeTypeName("const char *")]
        public sbyte* orderBy;
    }
}
