namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementAddUsernamePasswordResult
    {
        [NativeTypeName("const char *")]
        public sbyte* username;
    }
}
