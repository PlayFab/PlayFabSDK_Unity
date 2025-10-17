namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementNintendoSwitchPlayFabIdPair
    {
        [NativeTypeName("const char *")]
        public sbyte* nintendoSwitchDeviceId;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
