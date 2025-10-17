namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementSteamPlayFabIdPair
    {
        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const char *")]
        public sbyte* steamStringId;
    }
}
