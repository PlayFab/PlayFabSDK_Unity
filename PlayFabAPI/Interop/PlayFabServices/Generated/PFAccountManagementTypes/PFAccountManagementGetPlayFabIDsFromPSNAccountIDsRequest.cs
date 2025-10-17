namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromPSNAccountIDsRequest
    {
        [NativeTypeName("const int32_t *")]
        public int* issuerId;

        [NativeTypeName("const char *const *")]
        public sbyte** PSNAccountIDs;

        [NativeTypeName("uint32_t")]
        public uint PSNAccountIDsCount;
    }
}
