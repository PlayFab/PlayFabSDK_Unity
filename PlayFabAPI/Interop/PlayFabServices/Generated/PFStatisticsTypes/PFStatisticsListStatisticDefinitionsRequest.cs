namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsListStatisticDefinitionsRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const int32_t *")]
        public int* pageSize;

        [NativeTypeName("const char *")]
        public sbyte* skipToken;
    }
}
