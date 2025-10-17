namespace PlayFab.Interop
{
    public unsafe partial struct PFLeaderboardsGetEntityLeaderboardRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* leaderboardName;

        [NativeTypeName("uint32_t")]
        public uint pageSize;

        [NativeTypeName("const uint32_t *")]
        public uint* startingPosition;

        [NativeTypeName("const uint32_t *")]
        public uint* version;
    }
}
