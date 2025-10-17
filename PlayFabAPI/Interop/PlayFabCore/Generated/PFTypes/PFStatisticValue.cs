namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticValue
    {
        [NativeTypeName("const char *")]
        public sbyte* statisticName;

        [NativeTypeName("int32_t")]
        public int value;

        [NativeTypeName("uint32_t")]
        public uint version;
    }
}
