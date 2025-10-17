namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsGetGroupRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* group;

        [NativeTypeName("const char *")]
        public sbyte* groupName;
    }
}
