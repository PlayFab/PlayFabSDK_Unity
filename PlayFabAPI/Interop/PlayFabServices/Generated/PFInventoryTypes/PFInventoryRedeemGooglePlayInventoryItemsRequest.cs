namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryRedeemGooglePlayInventoryItemsRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* collectionId;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const PFInventoryGooglePlayProductPurchase *const *")]
        public PFInventoryGooglePlayProductPurchase** purchases;

        [NativeTypeName("uint32_t")]
        public uint purchasesCount;
    }
}
