namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementOpenIdSubjectIdentifier
    {
        [NativeTypeName("const char *")]
        public sbyte* issuer;

        [NativeTypeName("const char *")]
        public sbyte* subject;
    }
}
