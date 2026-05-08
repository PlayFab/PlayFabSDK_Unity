namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryRedemptionSuccess
    {
        [NativeTypeName("const time_t *")]
        public long* expirationTimestamp;

        [NativeTypeName("const char *")]
        public sbyte* marketplaceAlternateId;

        [NativeTypeName("const char *")]
        public sbyte* marketplaceTransactionId;

        [NativeTypeName("time_t")]
        public long successTimestamp;
    }
}
