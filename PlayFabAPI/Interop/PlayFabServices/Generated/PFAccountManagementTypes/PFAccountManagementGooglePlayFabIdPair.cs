namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGooglePlayFabIdPair
    {
        [NativeTypeName("const char *")]
        public sbyte* googleId;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
