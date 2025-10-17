namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsStatisticColumnCollection
    {
        [NativeTypeName("const PFStatisticsStatisticColumn *const *")]
        public PFStatisticsStatisticColumn** columns;

        [NativeTypeName("uint32_t")]
        public uint columnsCount;
    }
}
