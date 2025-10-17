namespace PlayFab.Interop
{
    public unsafe partial struct PFProfilesGetEntityProfileRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const bool *")]
        public byte* dataAsObject;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;
    }
}
