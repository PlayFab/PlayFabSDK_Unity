namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsCreateStatisticDefinitionRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** aggregationSources;

        [NativeTypeName("uint32_t")]
        public uint aggregationSourcesCount;

        [NativeTypeName("const PFStatisticsStatisticColumn *const *")]
        public PFStatisticsStatisticColumn** columns;

        [NativeTypeName("uint32_t")]
        public uint columnsCount;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* entityType;

        [NativeTypeName("const PFStatisticsStatisticsEventEmissionConfig *")]
        public PFStatisticsStatisticsEventEmissionConfig* eventEmissionConfig;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const PFVersionConfiguration *")]
        public PFVersionConfiguration* versionConfiguration;
    }
}
