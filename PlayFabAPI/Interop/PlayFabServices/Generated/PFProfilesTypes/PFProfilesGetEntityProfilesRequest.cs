namespace PlayFab.Interop
{
    public unsafe partial struct PFProfilesGetEntityProfilesRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const bool *")]
        public byte* dataAsObject;

        [NativeTypeName("const PFEntityKey *const *")]
        public PFEntityKey** entities;

        [NativeTypeName("uint32_t")]
        public uint entitiesCount;
    }
}
