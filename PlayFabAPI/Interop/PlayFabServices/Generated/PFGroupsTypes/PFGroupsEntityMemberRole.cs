namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsEntityMemberRole
    {
        [NativeTypeName("const PFGroupsEntityWithLineage *const *")]
        public PFGroupsEntityWithLineage** members;

        [NativeTypeName("uint32_t")]
        public uint membersCount;

        [NativeTypeName("const char *")]
        public sbyte* roleId;

        [NativeTypeName("const char *")]
        public sbyte* roleName;
    }
}
