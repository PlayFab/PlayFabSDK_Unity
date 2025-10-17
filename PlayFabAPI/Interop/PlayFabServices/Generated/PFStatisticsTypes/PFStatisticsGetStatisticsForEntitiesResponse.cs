namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsGetStatisticsForEntitiesResponse
    {
        [NativeTypeName("const struct PFStatisticsStatisticColumnCollectionDictionaryEntry *")]
        public PFStatisticsStatisticColumnCollectionDictionaryEntry* columnDetails;

        [NativeTypeName("uint32_t")]
        public uint columnDetailsCount;

        [NativeTypeName("const PFStatisticsEntityStatistics *const *")]
        public PFStatisticsEntityStatistics** entitiesStatistics;

        [NativeTypeName("uint32_t")]
        public uint entitiesStatisticsCount;
    }
}
