namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryExecuteTransferOperationsResponse
    {
        [NativeTypeName("const char *")]
        public sbyte* givingETag;

        [NativeTypeName("const char *const *")]
        public sbyte** givingTransactionIds;

        [NativeTypeName("uint32_t")]
        public uint givingTransactionIdsCount;

        [NativeTypeName("const char *")]
        public sbyte* idempotencyId;

        [NativeTypeName("const char *")]
        public sbyte* operationStatus;

        [NativeTypeName("const char *")]
        public sbyte* operationToken;

        [NativeTypeName("const char *")]
        public sbyte* receivingETag;

        [NativeTypeName("const char *const *")]
        public sbyte** receivingTransactionIds;

        [NativeTypeName("uint32_t")]
        public uint receivingTransactionIdsCount;
    }
}
