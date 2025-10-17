namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementFacebookInstantGamesPlayFabIdPair
    {
        [NativeTypeName("const char *")]
        public sbyte* facebookInstantGamesId;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
