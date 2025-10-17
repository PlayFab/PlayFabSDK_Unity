namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsGetStatisticsRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const char *const *")]
        public sbyte** statisticNames;

        [NativeTypeName("uint32_t")]
        public uint statisticNamesCount;
    }
}
