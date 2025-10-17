namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryGetTransactionHistoryResponse
    {
        [NativeTypeName("const char *")]
        public sbyte* continuationToken;

        [NativeTypeName("const PFInventoryTransaction *const *")]
        public PFInventoryTransaction** transactions;

        [NativeTypeName("uint32_t")]
        public uint transactionsCount;
    }
}
