namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsChangeMemberRoleRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* destinationRoleId;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* group;

        [NativeTypeName("const PFEntityKey *const *")]
        public PFEntityKey** members;

        [NativeTypeName("uint32_t")]
        public uint membersCount;

        [NativeTypeName("const char *")]
        public sbyte* originRoleId;
    }
}
