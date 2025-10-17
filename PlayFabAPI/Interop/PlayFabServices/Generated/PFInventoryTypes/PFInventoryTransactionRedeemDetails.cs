namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryTransactionRedeemDetails
    {
        [NativeTypeName("const char *")]
        public sbyte* marketplace;

        [NativeTypeName("const char *")]
        public sbyte* marketplaceTransactionId;

        [NativeTypeName("const char *")]
        public sbyte* offerId;
    }
}
