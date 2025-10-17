namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetAccountInfoRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* email;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const char *")]
        public sbyte* titleDisplayName;

        [NativeTypeName("const char *")]
        public sbyte* username;
    }
}
