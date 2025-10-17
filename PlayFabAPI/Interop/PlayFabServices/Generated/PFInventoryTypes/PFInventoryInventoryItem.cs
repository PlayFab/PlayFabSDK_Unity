namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryInventoryItem
    {
        [NativeTypeName("const int32_t *")]
        public int* amount;

        public PFJsonObject displayProperties;

        [NativeTypeName("const time_t *")]
        public long* expirationDate;

        [NativeTypeName("const char *")]
        public sbyte* id;

        [NativeTypeName("const char *")]
        public sbyte* stackId;

        [NativeTypeName("const char *")]
        public sbyte* type;
    }
}
