namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromGameCenterIDsRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** gameCenterIDs;

        [NativeTypeName("uint32_t")]
        public uint gameCenterIDsCount;
    }
}
