namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetUserAccountInfoRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
