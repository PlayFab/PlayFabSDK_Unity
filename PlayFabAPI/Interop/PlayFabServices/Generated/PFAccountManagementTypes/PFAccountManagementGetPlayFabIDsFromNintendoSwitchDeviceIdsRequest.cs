namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromNintendoSwitchDeviceIdsRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** nintendoSwitchDeviceIds;

        [NativeTypeName("uint32_t")]
        public uint nintendoSwitchDeviceIdsCount;
    }
}
