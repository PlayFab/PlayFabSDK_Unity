namespace PlayFab.Interop
{
    public unsafe partial struct PFLeaderboardsUpdateLeaderboardEntriesRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFLeaderboardsLeaderboardEntryUpdate *const *")]
        public PFLeaderboardsLeaderboardEntryUpdate** entries;

        [NativeTypeName("uint32_t")]
        public uint entriesCount;

        [NativeTypeName("const char *")]
        public sbyte* leaderboardName;
    }
}
