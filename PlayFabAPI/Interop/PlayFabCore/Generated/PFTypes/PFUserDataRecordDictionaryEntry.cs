namespace PlayFab.Interop
{
    public unsafe partial struct PFUserDataRecordDictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("const PFUserDataRecord *")]
        public PFUserDataRecord* value;
    }
}
