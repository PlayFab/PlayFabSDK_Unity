namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsUpdateGroupRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* adminRoleId;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const int32_t *")]
        public int* expectedProfileVersion;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* group;

        [NativeTypeName("const char *")]
        public sbyte* groupName;

        [NativeTypeName("const char *")]
        public sbyte* memberRoleId;
    }
}
