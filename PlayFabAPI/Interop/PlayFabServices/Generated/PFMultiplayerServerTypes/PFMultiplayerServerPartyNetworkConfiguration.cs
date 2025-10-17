namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerPartyNetworkConfiguration
    {
        [NativeTypeName("const char *")]
        public sbyte* directPeerConnectivityOptions;

        [NativeTypeName("uint32_t")]
        public uint maxDevices;

        [NativeTypeName("uint32_t")]
        public uint maxDevicesPerUser;

        [NativeTypeName("uint32_t")]
        public uint maxEndpointsPerDevice;

        [NativeTypeName("uint32_t")]
        public uint maxUsers;

        [NativeTypeName("uint32_t")]
        public uint maxUsersPerDevice;

        [NativeTypeName("const PFMultiplayerServerPartyInvitationConfiguration *")]
        public PFMultiplayerServerPartyInvitationConfiguration* partyInvitationConfiguration;
    }
}
