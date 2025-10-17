namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsStatisticDefinition
    {
        [NativeTypeName("const char *const *")]
        public sbyte** aggregationDestinations;

        [NativeTypeName("uint32_t")]
        public uint aggregationDestinationsCount;

        [NativeTypeName("const char *const *")]
        public sbyte** aggregationSources;

        [NativeTypeName("uint32_t")]
        public uint aggregationSourcesCount;

        [NativeTypeName("const PFStatisticsStatisticColumn *const *")]
        public PFStatisticsStatisticColumn** columns;

        [NativeTypeName("uint32_t")]
        public uint columnsCount;

        [NativeTypeName("time_t")]
        public long created;

        [NativeTypeName("const char *")]
        public sbyte* entityType;

        [NativeTypeName("const PFStatisticsStatisticsEventEmissionConfig *")]
        public PFStatisticsStatisticsEventEmissionConfig* eventEmissionConfig;

        [NativeTypeName("const time_t *")]
        public long* lastResetTime;

        [NativeTypeName("const char *const *")]
        public sbyte** linkedLeaderboardNames;

        [NativeTypeName("uint32_t")]
        public uint linkedLeaderboardNamesCount;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("uint32_t")]
        public uint version;

        [NativeTypeName("const PFVersionConfiguration *")]
        public PFVersionConfiguration* versionConfiguration;
    }
}
