namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerListQosServersForTitleResponse
    {
        [NativeTypeName("int32_t")]
        public int pageSize;

        [NativeTypeName("const PFMultiplayerServerQosServer *const *")]
        public PFMultiplayerServerQosServer** qosServers;

        [NativeTypeName("uint32_t")]
        public uint qosServersCount;

        [NativeTypeName("const char *")]
        public sbyte* skipToken;
    }
}
