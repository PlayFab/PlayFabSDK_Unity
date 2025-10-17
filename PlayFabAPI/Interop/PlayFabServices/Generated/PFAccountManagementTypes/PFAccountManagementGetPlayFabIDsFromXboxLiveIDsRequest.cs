namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromXboxLiveIDsRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* sandbox;

        [NativeTypeName("const char *const *")]
        public sbyte** xboxLiveAccountIDs;

        [NativeTypeName("uint32_t")]
        public uint xboxLiveAccountIDsCount;
    }
}
