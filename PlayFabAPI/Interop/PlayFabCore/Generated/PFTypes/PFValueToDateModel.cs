namespace PlayFab.Interop
{
    public unsafe partial struct PFValueToDateModel
    {
        [NativeTypeName("const char *")]
        public sbyte* currency;

        [NativeTypeName("uint32_t")]
        public uint totalValue;

        [NativeTypeName("const char *")]
        public sbyte* totalValueAsDecimal;
    }
}
