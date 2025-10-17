namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsStatisticColumnCollectionDictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("const PFStatisticsStatisticColumnCollection *")]
        public PFStatisticsStatisticColumnCollection* value;
    }
}
