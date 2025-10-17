using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    public unsafe partial struct PFLobbyMemberUpdateSummary
    {
        public PFEntityKey member;

        public byte connectionStatusUpdated;

        [NativeTypeName("uint32_t")]
        public uint updatedMemberPropertyCount;

        [NativeTypeName("const char *const *")]
        public sbyte** updatedMemberPropertyKeys;
    }
}
