namespace PlayFab.Interop
{
    public unsafe partial struct PFUserFacebookInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* facebookId;

        [NativeTypeName("const char *")]
        public sbyte* fullName;
    }
}
