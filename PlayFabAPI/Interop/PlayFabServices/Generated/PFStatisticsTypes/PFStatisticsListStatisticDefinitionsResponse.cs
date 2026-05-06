namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsListStatisticDefinitionsResponse
    {
        [NativeTypeName("int32_t")]
        public int pageSize;

        [NativeTypeName("const char *")]
        public sbyte* skipToken;

        [NativeTypeName("const PFStatisticsStatisticDefinition *const *")]
        public PFStatisticsStatisticDefinition** statisticDefinitions;

        [NativeTypeName("uint32_t")]
        public uint statisticDefinitionsCount;
    }
}
