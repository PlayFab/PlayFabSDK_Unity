namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementXboxLiveAccountPlayFabIdPair
    {
        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const char *")]
        public sbyte* xboxLiveAccountId;
    }
}
