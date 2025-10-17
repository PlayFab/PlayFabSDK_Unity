using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    [NativeTypeName("struct PFLobbyLeaveLobbyCompletedStateChange : PFLobbyStateChange")]
    public unsafe partial struct PFLobbyLeaveLobbyCompletedStateChange
    {
        public PFLobbyStateChange __AnonymousBase_1;

        [NativeTypeName("PFLobbyHandle")]
        public PFLobby* lobby;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* localUser;

        public void* asyncContext;
    }
}
