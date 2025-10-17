namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryRedeemSteamInventoryItemsRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* collectionId;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;
    }
}
