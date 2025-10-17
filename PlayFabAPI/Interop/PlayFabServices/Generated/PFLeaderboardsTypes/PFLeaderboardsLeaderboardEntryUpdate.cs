namespace PlayFab.Interop
{
    public unsafe partial struct PFLeaderboardsLeaderboardEntryUpdate
    {
        [NativeTypeName("const char *")]
        public sbyte* entityId;

        [NativeTypeName("const char *")]
        public sbyte* metadata;

        [NativeTypeName("const char *const *")]
        public sbyte** scores;

        [NativeTypeName("uint32_t")]
        public uint scoresCount;
    }
}
