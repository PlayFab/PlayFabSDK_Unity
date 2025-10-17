namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryTransactionOperation
    {
        [NativeTypeName("const int32_t *")]
        public int* amount;

        [NativeTypeName("const double *")]
        public double* durationInSeconds;

        [NativeTypeName("const char *")]
        public sbyte* itemFriendlyId;

        [NativeTypeName("const char *")]
        public sbyte* itemId;

        [NativeTypeName("const char *")]
        public sbyte* itemType;

        [NativeTypeName("const char *")]
        public sbyte* stackId;

        [NativeTypeName("const char *")]
        public sbyte* type;
    }
}
