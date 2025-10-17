using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    [NativeTypeName("struct PFLobbyConnectToLobbyCompletedStateChange : PFLobbyStateChange")]
    public unsafe partial struct PFLobbyConnectToLobbyCompletedStateChange
    {
        public PFLobbyStateChange __AnonymousBase_1;

        public int result;

        public PFEntityKey newMember;

        [NativeTypeName("const char *")]
        public sbyte* lobbyId;

        public void* asyncContext;

        [NativeTypeName("PFLobbyHandle")]
        public PFLobby* lobby;
    }
}
