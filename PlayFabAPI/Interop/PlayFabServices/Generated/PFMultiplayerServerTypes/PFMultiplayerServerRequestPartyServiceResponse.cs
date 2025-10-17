namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerRequestPartyServiceResponse
    {
        [NativeTypeName("const char *")]
        public sbyte* invitationId;

        [NativeTypeName("const char *")]
        public sbyte* partyId;

        [NativeTypeName("const char *")]
        public sbyte* serializedNetworkDescriptor;
    }
}
