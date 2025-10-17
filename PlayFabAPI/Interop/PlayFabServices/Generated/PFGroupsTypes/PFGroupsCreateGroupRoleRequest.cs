namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsCreateGroupRoleRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* group;

        [NativeTypeName("const char *")]
        public sbyte* roleId;

        [NativeTypeName("const char *")]
        public sbyte* roleName;
    }
}
