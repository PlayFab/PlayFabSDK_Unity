using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    [NativeTypeName("struct PFLobbyMemberAddedStateChange : PFLobbyStateChange")]
    public unsafe partial struct PFLobbyMemberAddedStateChange
    {
        public PFLobbyStateChange __AnonymousBase_1;

        [NativeTypeName("PFLobbyHandle")]
        public PFLobby* lobby;

        public PFEntityKey member;
    }
}
