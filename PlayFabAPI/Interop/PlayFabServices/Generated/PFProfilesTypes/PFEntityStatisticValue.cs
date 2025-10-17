namespace PlayFab.Interop
{
    public unsafe partial struct PFEntityStatisticValue
    {
        [NativeTypeName("const char *")]
        public sbyte* metadata;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *const *")]
        public sbyte** scores;

        [NativeTypeName("uint32_t")]
        public uint scoresCount;

        [NativeTypeName("int32_t")]
        public int version;
    }
}
