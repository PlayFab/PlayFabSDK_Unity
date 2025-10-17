namespace PlayFab.Interop
{
    public unsafe partial struct PFTitleDataManagementGetTitleDataResult
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
