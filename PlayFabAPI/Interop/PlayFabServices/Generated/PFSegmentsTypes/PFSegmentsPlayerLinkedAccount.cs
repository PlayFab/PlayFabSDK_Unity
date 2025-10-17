namespace PlayFab.Interop
{
    public unsafe partial struct PFSegmentsPlayerLinkedAccount
    {
        [NativeTypeName("const char *")]
        public sbyte* email;

        [NativeTypeName("const PFLoginIdentityProvider *")]
        public PFLoginIdentityProvider* platform;

        [NativeTypeName("const char *")]
        public sbyte* platformUserId;

        [NativeTypeName("const char *")]
        public sbyte* username;
    }
}
