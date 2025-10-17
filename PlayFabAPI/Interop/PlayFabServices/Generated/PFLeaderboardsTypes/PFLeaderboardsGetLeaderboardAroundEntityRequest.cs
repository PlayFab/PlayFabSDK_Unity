namespace PlayFab.Interop
{
    public unsafe partial struct PFLeaderboardsGetLeaderboardAroundEntityRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const char *")]
        public sbyte* leaderboardName;

        [NativeTypeName("uint32_t")]
        public uint maxSurroundingEntries;

        [NativeTypeName("const uint32_t *")]
        public uint* version;
    }
}
