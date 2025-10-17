using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    public unsafe partial struct PFMatchmakingServerBackfillTicketConfiguration
    {
        [NativeTypeName("uint32_t")]
        public uint timeoutInSeconds;

        [NativeTypeName("const char *")]
        public sbyte* queueName;

        [NativeTypeName("uint32_t")]
        public uint memberCount;

        [NativeTypeName("const PFMatchmakingMatchMember *")]
        public PFMatchmakingMatchMember* members;

        [NativeTypeName("const PFMultiplayerServerDetails *")]
        public PFMultiplayerServerDetails* serverDetails;
    }
}
