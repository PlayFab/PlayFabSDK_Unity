namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryRedemptionFailure
    {
        [NativeTypeName("const char *")]
        public sbyte* failureCode;

        [NativeTypeName("const char *")]
        public sbyte* failureDetails;

        [NativeTypeName("const char *")]
        public sbyte* marketplaceAlternateId;

        [NativeTypeName("const char *")]
        public sbyte* marketplaceTransactionId;
    }
}
