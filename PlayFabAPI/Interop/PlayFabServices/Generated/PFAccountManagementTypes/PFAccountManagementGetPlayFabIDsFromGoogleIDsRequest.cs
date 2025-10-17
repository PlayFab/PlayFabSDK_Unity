namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromGoogleIDsRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** googleIDs;

        [NativeTypeName("uint32_t")]
        public uint googleIDsCount;
    }
}
