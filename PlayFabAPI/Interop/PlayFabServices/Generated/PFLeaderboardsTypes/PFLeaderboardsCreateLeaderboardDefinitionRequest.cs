namespace PlayFab.Interop
{
    public unsafe partial struct PFLeaderboardsCreateLeaderboardDefinitionRequest
    {
        [NativeTypeName("const PFLeaderboardsLeaderboardColumn *const *")]
        public PFLeaderboardsLeaderboardColumn** columns;

        [NativeTypeName("uint32_t")]
        public uint columnsCount;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* entityType;

        [NativeTypeName("const PFLeaderboardsLeaderboardEventEmissionConfig *")]
        public PFLeaderboardsLeaderboardEventEmissionConfig* eventEmissionConfig;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("int32_t")]
        public int sizeLimit;

        [NativeTypeName("const PFVersionConfiguration *")]
        public PFVersionConfiguration* versionConfiguration;
    }
}
