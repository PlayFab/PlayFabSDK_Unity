namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerPort
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("int32_t")]
        public int num;

        public PFMultiplayerServerProtocolType protocol;
    }
}
