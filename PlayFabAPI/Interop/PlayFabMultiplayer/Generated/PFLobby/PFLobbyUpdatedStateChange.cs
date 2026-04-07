using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    [NativeTypeName("struct PFLobbyUpdatedStateChange : PFLobbyStateChange")]
    public unsafe partial struct PFLobbyUpdatedStateChange
    {
        public PFLobbyStateChange __AnonymousBase_1;

        [NativeTypeName("PFLobbyHandle")]
        public PFLobby* lobby;

        public byte ownerUpdated;

        public byte maxMembersUpdated;

        public byte accessPolicyUpdated;

        public byte membershipLockUpdated;

        [NativeTypeName("uint32_t")]
        public uint updatedSearchPropertyCount;

        [NativeTypeName("const char *const *")]
        public sbyte** updatedSearchPropertyKeys;

        [NativeTypeName("uint32_t")]
        public uint updatedLobbyPropertyCount;

        [NativeTypeName("const char *const *")]
        public sbyte** updatedLobbyPropertyKeys;

        [NativeTypeName("uint32_t")]
        public uint memberUpdateCount;

        [NativeTypeName("const PFLobbyMemberUpdateSummary *")]
        public PFLobbyMemberUpdateSummary* memberUpdates;

        public byte serverUpdated;

        [NativeTypeName("uint32_t")]
        public uint updatedServerPropertyCount;

        [NativeTypeName("const char *const *")]
        public sbyte** updatedServerPropertyKeys;

        public byte serverConnectionStatusUpdated;

        public byte restrictInvitesToLobbyOwnerUpdated;
    }
}
