namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsGetStatisticsResponse
    {
        [NativeTypeName("const struct PFStatisticsStatisticColumnCollectionDictionaryEntry *")]
        public PFStatisticsStatisticColumnCollectionDictionaryEntry* columnDetails;

        [NativeTypeName("uint32_t")]
        public uint columnDetailsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const struct PFStatisticsEntityStatisticValueDictionaryEntry *")]
        public PFStatisticsEntityStatisticValueDictionaryEntry* statistics;

        [NativeTypeName("uint32_t")]
        public uint statisticsCount;
    }
}
