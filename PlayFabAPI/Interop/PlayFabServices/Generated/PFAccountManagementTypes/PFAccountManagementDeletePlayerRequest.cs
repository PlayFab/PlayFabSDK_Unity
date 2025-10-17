namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementDeletePlayerRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
