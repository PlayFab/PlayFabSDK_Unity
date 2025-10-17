namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsListStatisticDefinitionsResponse
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFStatisticsStatisticDefinition *const *")]
        public PFStatisticsStatisticDefinition** statisticDefinitions;

        [NativeTypeName("uint32_t")]
        public uint statisticDefinitionsCount;
    }
}
