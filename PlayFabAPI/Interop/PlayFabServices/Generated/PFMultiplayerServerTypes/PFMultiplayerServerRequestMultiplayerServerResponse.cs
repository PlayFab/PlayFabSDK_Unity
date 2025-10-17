namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerRequestMultiplayerServerResponse
    {
        [NativeTypeName("const char *")]
        public sbyte* buildId;

        [NativeTypeName("const PFMultiplayerServerConnectedPlayer *const *")]
        public PFMultiplayerServerConnectedPlayer** connectedPlayers;

        [NativeTypeName("uint32_t")]
        public uint connectedPlayersCount;

        [NativeTypeName("const char *")]
        public sbyte* fQDN;

        [NativeTypeName("const char *")]
        public sbyte* iPV4Address;

        [NativeTypeName("const time_t *")]
        public long* lastStateTransitionTime;

        [NativeTypeName("const PFMultiplayerServerPort *const *")]
        public PFMultiplayerServerPort** ports;

        [NativeTypeName("uint32_t")]
        public uint portsCount;

        [NativeTypeName("const PFMultiplayerServerPublicIpAddress *const *")]
        public PFMultiplayerServerPublicIpAddress** publicIPV4Addresses;

        [NativeTypeName("uint32_t")]
        public uint publicIPV4AddressesCount;

        [NativeTypeName("const char *")]
        public sbyte* region;

        [NativeTypeName("const char *")]
        public sbyte* serverId;

        [NativeTypeName("const char *")]
        public sbyte* sessionId;

        [NativeTypeName("const char *")]
        public sbyte* state;

        [NativeTypeName("const char *")]
        public sbyte* vmId;
    }
}
