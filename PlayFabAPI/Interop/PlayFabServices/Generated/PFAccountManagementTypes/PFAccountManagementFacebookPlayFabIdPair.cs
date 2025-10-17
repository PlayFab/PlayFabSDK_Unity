namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementFacebookPlayFabIdPair
    {
        [NativeTypeName("const char *")]
        public sbyte* facebookId;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
