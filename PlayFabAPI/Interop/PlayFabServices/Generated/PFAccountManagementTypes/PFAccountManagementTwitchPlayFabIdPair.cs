namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementTwitchPlayFabIdPair
    {
        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const char *")]
        public sbyte* twitchId;
    }
}
