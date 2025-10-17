namespace PlayFab.Interop
{
    public unsafe partial struct PFUserOpenIdInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* connectionId;

        [NativeTypeName("const char *")]
        public sbyte* issuer;

        [NativeTypeName("const char *")]
        public sbyte* subject;
    }
}
