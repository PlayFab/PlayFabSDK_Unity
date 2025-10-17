namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsEntityStatisticValueDictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("const PFStatisticsEntityStatisticValue *")]
        public PFStatisticsEntityStatisticValue* value;
    }
}
