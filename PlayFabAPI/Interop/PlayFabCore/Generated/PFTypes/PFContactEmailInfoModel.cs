namespace PlayFab.Interop
{
    public unsafe partial struct PFContactEmailInfoModel
    {
        [NativeTypeName("const char *")]
        public sbyte* emailAddress;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const PFEmailVerificationStatus *")]
        public PFEmailVerificationStatus* verificationStatus;
    }
}
