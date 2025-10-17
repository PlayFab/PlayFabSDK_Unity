namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetServerCustomIDsFromPlayFabIDsResult
    {
        [NativeTypeName("const PFAccountManagementServerCustomIDPlayFabIDPair *const *")]
        public PFAccountManagementServerCustomIDPlayFabIDPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
