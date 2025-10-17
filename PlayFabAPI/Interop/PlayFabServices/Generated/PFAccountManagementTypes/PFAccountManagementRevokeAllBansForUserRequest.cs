namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementRevokeAllBansForUserRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
