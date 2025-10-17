namespace PlayFab.Interop
{
    public unsafe partial struct PFLeaderboardsEntityLeaderboardEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* displayName;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("time_t")]
        public long lastUpdated;

        [NativeTypeName("const char *")]
        public sbyte* metadata;

        [NativeTypeName("int32_t")]
        public int rank;

        [NativeTypeName("const char *const *")]
        public sbyte** scores;

        [NativeTypeName("uint32_t")]
        public uint scoresCount;
    }
}
