namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromKongregateIDsResult
    {
        [NativeTypeName("const PFAccountManagementKongregatePlayFabIdPair *const *")]
        public PFAccountManagementKongregatePlayFabIdPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
