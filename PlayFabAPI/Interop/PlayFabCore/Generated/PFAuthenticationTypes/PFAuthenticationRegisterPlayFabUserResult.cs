namespace PlayFab.Interop
{
    public unsafe partial struct PFAuthenticationRegisterPlayFabUserResult
    {
        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const PFAuthenticationUserSettings *")]
        public PFAuthenticationUserSettings* settingsForUser;

        [NativeTypeName("const char *")]
        public sbyte* username;
    }
}
