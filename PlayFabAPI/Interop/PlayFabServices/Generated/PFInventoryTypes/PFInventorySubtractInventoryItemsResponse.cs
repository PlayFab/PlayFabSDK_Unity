namespace PlayFab.Interop
{
    public unsafe partial struct PFInventorySubtractInventoryItemsResponse
    {
        [NativeTypeName("const char *")]
        public sbyte* eTag;

        [NativeTypeName("const char *")]
        public sbyte* idempotencyId;

        [NativeTypeName("const char *const *")]
        public sbyte** transactionIds;

        [NativeTypeName("uint32_t")]
        public uint transactionIdsCount;
    }
}
