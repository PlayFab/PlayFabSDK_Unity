namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsGetStatisticsForEntitiesRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *const *")]
        public PFEntityKey** entities;

        [NativeTypeName("uint32_t")]
        public uint entitiesCount;

        [NativeTypeName("const char *const *")]
        public sbyte** statisticNames;

        [NativeTypeName("uint32_t")]
        public uint statisticNamesCount;
    }
}
