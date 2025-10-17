namespace PlayFab.Interop
{
    public unsafe partial struct PFSegmentsPlayerStatistic
    {
        [NativeTypeName("const char *")]
        public sbyte* id;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("int32_t")]
        public int statisticValue;

        [NativeTypeName("int32_t")]
        public int statisticVersion;
    }
}
