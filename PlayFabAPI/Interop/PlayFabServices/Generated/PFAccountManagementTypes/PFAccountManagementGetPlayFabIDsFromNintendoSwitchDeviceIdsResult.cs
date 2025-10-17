namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsResult
    {
        [NativeTypeName("const PFAccountManagementNintendoSwitchPlayFabIdPair *const *")]
        public PFAccountManagementNintendoSwitchPlayFabIdPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
