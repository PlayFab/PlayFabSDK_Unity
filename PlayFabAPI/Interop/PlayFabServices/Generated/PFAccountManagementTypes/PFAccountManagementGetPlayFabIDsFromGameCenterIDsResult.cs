namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromGameCenterIDsResult
    {
        [NativeTypeName("const PFAccountManagementGameCenterPlayFabIdPair *const *")]
        public PFAccountManagementGameCenterPlayFabIdPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
