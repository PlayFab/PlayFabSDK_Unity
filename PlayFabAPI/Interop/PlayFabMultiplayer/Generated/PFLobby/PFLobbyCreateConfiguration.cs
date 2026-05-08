using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    public unsafe partial struct PFLobbyCreateConfiguration
    {
        [NativeTypeName("uint32_t")]
        public uint maxMemberCount;

        public PFLobbyOwnerMigrationPolicy ownerMigrationPolicy;

        public PFLobbyAccessPolicy accessPolicy;

        [NativeTypeName("uint32_t")]
        public uint searchPropertyCount;

        [NativeTypeName("const char *const *")]
        public sbyte** searchPropertyKeys;

        [NativeTypeName("const char *const *")]
        public sbyte** searchPropertyValues;

        [NativeTypeName("uint32_t")]
        public uint lobbyPropertyCount;

        [NativeTypeName("const char *const *")]
        public sbyte** lobbyPropertyKeys;

        [NativeTypeName("const char *const *")]
        public sbyte** lobbyPropertyValues;

        public byte restrictInvitesToLobbyOwner;
    }
}
