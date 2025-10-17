namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetUserBansRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
