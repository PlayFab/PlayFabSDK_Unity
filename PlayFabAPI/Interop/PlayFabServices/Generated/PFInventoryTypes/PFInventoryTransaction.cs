namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryTransaction
    {
        [NativeTypeName("const char *")]
        public sbyte* apiName;

        [NativeTypeName("const PFInventoryTransactionClawbackDetails *")]
        public PFInventoryTransactionClawbackDetails* clawbackDetails;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* itemType;

        [NativeTypeName("const PFInventoryTransactionOperation *const *")]
        public PFInventoryTransactionOperation** operations;

        [NativeTypeName("uint32_t")]
        public uint operationsCount;

        [NativeTypeName("const char *")]
        public sbyte* operationType;

        [NativeTypeName("const PFInventoryTransactionPurchaseDetails *")]
        public PFInventoryTransactionPurchaseDetails* purchaseDetails;

        [NativeTypeName("const PFInventoryTransactionRedeemDetails *")]
        public PFInventoryTransactionRedeemDetails* redeemDetails;

        [NativeTypeName("time_t")]
        public long timestamp;

        [NativeTypeName("const char *")]
        public sbyte* transactionId;

        [NativeTypeName("const PFInventoryTransactionTransferDetails *")]
        public PFInventoryTransactionTransferDetails* transferDetails;
    }
}
