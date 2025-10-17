namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromXboxLiveIDsResult
    {
        [NativeTypeName("const PFAccountManagementXboxLiveAccountPlayFabIdPair *const *")]
        public PFAccountManagementXboxLiveAccountPlayFabIdPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
