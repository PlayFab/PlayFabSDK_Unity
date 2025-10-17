namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsEntityStatistics
    {
        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entityKey;

        [NativeTypeName("const PFStatisticsEntityStatisticValue *const *")]
        public PFStatisticsEntityStatisticValue** statistics;

        [NativeTypeName("uint32_t")]
        public uint statisticsCount;
    }
}
