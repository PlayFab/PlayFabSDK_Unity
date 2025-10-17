namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** nintendoAccountIds;

        [NativeTypeName("uint32_t")]
        public uint nintendoAccountIdsCount;
    }
}
