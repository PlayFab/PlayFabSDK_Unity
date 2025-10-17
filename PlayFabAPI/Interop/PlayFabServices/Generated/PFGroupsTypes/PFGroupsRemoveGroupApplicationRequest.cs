namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsRemoveGroupApplicationRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* group;
    }
}
