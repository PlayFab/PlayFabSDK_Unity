namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementPSNOnlinePlayFabIdPair
    {
        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const char *")]
        public sbyte* PSNOnlineId;
    }
}
