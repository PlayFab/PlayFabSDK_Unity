namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementClientGetUserDataResult
    {
        [NativeTypeName("const struct PFUserDataRecordDictionaryEntry *")]
        public PFUserDataRecordDictionaryEntry* data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;

        [NativeTypeName("uint32_t")]
        public uint dataVersion;
    }
}
