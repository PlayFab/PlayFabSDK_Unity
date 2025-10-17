namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsStatisticColumn
    {
        public PFStatisticsStatisticAggregationMethod aggregationMethod;

        [NativeTypeName("const char *")]
        public sbyte* name;
    }
}
