namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementServerGetUserDataResult
    {
        [NativeTypeName("const struct PFUserDataRecordDictionaryEntry *")]
        public PFUserDataRecordDictionaryEntry* data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;

        [NativeTypeName("uint32_t")]
        public uint dataVersion;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
