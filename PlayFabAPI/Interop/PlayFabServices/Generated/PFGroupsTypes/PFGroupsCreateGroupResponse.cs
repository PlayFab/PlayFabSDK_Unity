namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsCreateGroupResponse
    {
        [NativeTypeName("const char *")]
        public sbyte* adminRoleId;

        [NativeTypeName("time_t")]
        public long created;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* group;

        [NativeTypeName("const char *")]
        public sbyte* groupName;

        [NativeTypeName("const char *")]
        public sbyte* memberRoleId;

        [NativeTypeName("int32_t")]
        public int profileVersion;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* roles;

        [NativeTypeName("uint32_t")]
        public uint rolesCount;
    }
}
