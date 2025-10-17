namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromFacebookIDsRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** facebookIDs;

        [NativeTypeName("uint32_t")]
        public uint facebookIDsCount;
    }
}
