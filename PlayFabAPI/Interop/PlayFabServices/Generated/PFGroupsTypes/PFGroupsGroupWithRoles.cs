namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsGroupWithRoles
    {
        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* group;

        [NativeTypeName("const char *")]
        public sbyte* groupName;

        [NativeTypeName("int32_t")]
        public int profileVersion;

        [NativeTypeName("const PFGroupsGroupRole *const *")]
        public PFGroupsGroupRole** roles;

        [NativeTypeName("uint32_t")]
        public uint rolesCount;
    }
}
