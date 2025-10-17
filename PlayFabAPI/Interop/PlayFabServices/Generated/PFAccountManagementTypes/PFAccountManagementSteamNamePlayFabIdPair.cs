namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementSteamNamePlayFabIdPair
    {
        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const char *")]
        public sbyte* steamName;
    }
}
