namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromPSNOnlineIDsRequest
    {
        [NativeTypeName("const int32_t *")]
        public int* issuerId;

        [NativeTypeName("const char *const *")]
        public sbyte** PSNOnlineIDs;

        [NativeTypeName("uint32_t")]
        public uint PSNOnlineIDsCount;
    }
}
