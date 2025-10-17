namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryRedeemPlayStationStoreInventoryItemsResponse
    {
        [NativeTypeName("const PFInventoryRedemptionFailure *const *")]
        public PFInventoryRedemptionFailure** failed;

        [NativeTypeName("uint32_t")]
        public uint failedCount;

        [NativeTypeName("const PFInventoryRedemptionSuccess *const *")]
        public PFInventoryRedemptionSuccess** succeeded;

        [NativeTypeName("uint32_t")]
        public uint succeededCount;

        [NativeTypeName("const char *const *")]
        public sbyte** transactionIds;

        [NativeTypeName("uint32_t")]
        public uint transactionIdsCount;
    }
}
