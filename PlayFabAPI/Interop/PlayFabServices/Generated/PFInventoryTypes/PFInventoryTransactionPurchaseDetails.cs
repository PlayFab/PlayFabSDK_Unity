namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryTransactionPurchaseDetails
    {
        [NativeTypeName("const char *")]
        public sbyte* itemFriendlyId;

        [NativeTypeName("const char *")]
        public sbyte* itemId;

        [NativeTypeName("const char *")]
        public sbyte* storeFriendlyId;

        [NativeTypeName("const char *")]
        public sbyte* storeId;
    }
}
