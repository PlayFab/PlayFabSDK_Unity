namespace PlayFab.Interop
{
    public unsafe partial struct PFLeaderboardsGetEntityLeaderboardResponse
    {
        [NativeTypeName("const PFLeaderboardsLeaderboardColumn *const *")]
        public PFLeaderboardsLeaderboardColumn** columns;

        [NativeTypeName("uint32_t")]
        public uint columnsCount;

        [NativeTypeName("uint32_t")]
        public uint entryCount;

        [NativeTypeName("const time_t *")]
        public long* nextReset;

        [NativeTypeName("const PFLeaderboardsEntityLeaderboardEntry *const *")]
        public PFLeaderboardsEntityLeaderboardEntry** rankings;

        [NativeTypeName("uint32_t")]
        public uint rankingsCount;

        [NativeTypeName("uint32_t")]
        public uint version;
    }
}
