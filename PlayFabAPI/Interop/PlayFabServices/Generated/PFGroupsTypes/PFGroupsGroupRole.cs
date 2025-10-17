namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsGroupRole
    {
        [NativeTypeName("const char *")]
        public sbyte* roleId;

        [NativeTypeName("const char *")]
        public sbyte* roleName;
    }
}
