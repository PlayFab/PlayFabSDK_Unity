namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsDeleteStatisticsRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const PFStatisticsStatisticDelete *const *")]
        public PFStatisticsStatisticDelete** statistics;

        [NativeTypeName("uint32_t")]
        public uint statisticsCount;
    }
}
