namespace PlayFab.Interop
{
    public unsafe partial struct PFLeaderboardsGetLeaderboardDefinitionResponse
    {
        [NativeTypeName("const PFLeaderboardsLeaderboardColumn *const *")]
        public PFLeaderboardsLeaderboardColumn** columns;

        [NativeTypeName("uint32_t")]
        public uint columnsCount;

        [NativeTypeName("time_t")]
        public long created;

        [NativeTypeName("const char *")]
        public sbyte* entityType;

        [NativeTypeName("const PFLeaderboardsLeaderboardEventEmissionConfig *")]
        public PFLeaderboardsLeaderboardEventEmissionConfig* eventEmissionConfig;

        [NativeTypeName("const time_t *")]
        public long* lastResetTime;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("int32_t")]
        public int sizeLimit;

        [NativeTypeName("uint32_t")]
        public uint version;

        [NativeTypeName("const PFVersionConfiguration *")]
        public PFVersionConfiguration* versionConfiguration;
    }
}
