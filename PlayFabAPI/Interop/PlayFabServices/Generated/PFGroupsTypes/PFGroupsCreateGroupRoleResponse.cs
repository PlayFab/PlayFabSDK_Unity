namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsCreateGroupRoleResponse
    {
        [NativeTypeName("int32_t")]
        public int profileVersion;

        [NativeTypeName("const char *")]
        public sbyte* roleId;

        [NativeTypeName("const char *")]
        public sbyte* roleName;
    }
}
