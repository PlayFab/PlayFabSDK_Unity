namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromKongregateIDsRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** kongregateIDs;

        [NativeTypeName("uint32_t")]
        public uint kongregateIDsCount;
    }
}
