namespace PlayFab.Interop
{
    public unsafe partial struct PFEntityStatisticValueDictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("const PFEntityStatisticValue *")]
        public PFEntityStatisticValue* value;
    }
}
