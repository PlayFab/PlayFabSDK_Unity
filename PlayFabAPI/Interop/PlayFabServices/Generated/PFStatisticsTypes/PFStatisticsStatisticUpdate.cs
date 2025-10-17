namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsStatisticUpdate
    {
        [NativeTypeName("const char *")]
        public sbyte* metadata;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *const *")]
        public sbyte** scores;

        [NativeTypeName("uint32_t")]
        public uint scoresCount;

        [NativeTypeName("const uint32_t *")]
        public uint* version;
    }
}
