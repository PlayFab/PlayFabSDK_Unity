namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerPublicIpAddress
    {
        [NativeTypeName("const char *")]
        public sbyte* fQDN;

        [NativeTypeName("const char *")]
        public sbyte* ipAddress;

        [NativeTypeName("const char *")]
        public sbyte* routingType;
    }
}
