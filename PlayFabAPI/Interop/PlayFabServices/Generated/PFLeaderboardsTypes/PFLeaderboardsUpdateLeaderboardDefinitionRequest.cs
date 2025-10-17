namespace PlayFab.Interop
{
    public unsafe partial struct PFLeaderboardsUpdateLeaderboardDefinitionRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFLeaderboardsLeaderboardEventEmissionConfig *")]
        public PFLeaderboardsLeaderboardEventEmissionConfig* eventEmissionConfig;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const int32_t *")]
        public int* sizeLimit;

        [NativeTypeName("const PFVersionConfiguration *")]
        public PFVersionConfiguration* versionConfiguration;
    }
}
