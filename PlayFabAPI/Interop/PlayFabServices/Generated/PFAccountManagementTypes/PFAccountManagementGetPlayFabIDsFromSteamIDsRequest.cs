namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromSteamIDsRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** steamStringIDs;

        [NativeTypeName("uint32_t")]
        public uint steamStringIDsCount;
    }
}
