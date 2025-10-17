namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromTwitchIDsRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** twitchIds;

        [NativeTypeName("uint32_t")]
        public uint twitchIdsCount;
    }
}
