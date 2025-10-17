namespace PlayFab.Interop
{
    public unsafe partial struct PFLeaderboardsGetLeaderboardForEntitiesRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *const *")]
        public sbyte** entityIds;

        [NativeTypeName("uint32_t")]
        public uint entityIdsCount;

        [NativeTypeName("const char *")]
        public sbyte* leaderboardName;

        [NativeTypeName("const uint32_t *")]
        public uint* version;
    }
}
