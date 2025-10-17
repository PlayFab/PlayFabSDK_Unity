namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsUpdateStatisticDefinitionRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFStatisticsStatisticsEventEmissionConfig *")]
        public PFStatisticsStatisticsEventEmissionConfig* eventEmissionConfig;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const PFVersionConfiguration *")]
        public PFVersionConfiguration* versionConfiguration;
    }
}
