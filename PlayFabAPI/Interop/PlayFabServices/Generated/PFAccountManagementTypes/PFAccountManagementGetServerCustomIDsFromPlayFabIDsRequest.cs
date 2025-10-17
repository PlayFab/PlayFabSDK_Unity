namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetServerCustomIDsFromPlayFabIDsRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** playFabIDs;

        [NativeTypeName("uint32_t")]
        public uint playFabIDsCount;
    }
}
