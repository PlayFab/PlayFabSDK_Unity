namespace PlayFab.Interop
{
    public unsafe partial struct PFUserGoogleInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* googleEmail;

        [NativeTypeName("const char *")]
        public sbyte* googleGender;

        [NativeTypeName("const char *")]
        public sbyte* googleId;

        [NativeTypeName("const char *")]
        public sbyte* googleLocale;

        [NativeTypeName("const char *")]
        public sbyte* googleName;
    }
}
