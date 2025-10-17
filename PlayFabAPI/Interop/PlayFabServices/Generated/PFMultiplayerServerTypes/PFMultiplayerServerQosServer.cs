namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerQosServer
    {
        [NativeTypeName("const char *")]
        public sbyte* region;

        [NativeTypeName("const char *")]
        public sbyte* serverUrl;
    }
}
