namespace PlayFab.Interop
{
    public unsafe partial struct PFSegmentsContactEmailInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* emailAddress;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const PFEmailVerificationStatus *")]
        public PFEmailVerificationStatus* verificationStatus;
    }
}
