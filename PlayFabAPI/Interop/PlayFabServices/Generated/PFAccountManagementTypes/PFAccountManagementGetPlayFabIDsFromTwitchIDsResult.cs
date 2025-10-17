namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromTwitchIDsResult
    {
        [NativeTypeName("const PFAccountManagementTwitchPlayFabIdPair *const *")]
        public PFAccountManagementTwitchPlayFabIdPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
