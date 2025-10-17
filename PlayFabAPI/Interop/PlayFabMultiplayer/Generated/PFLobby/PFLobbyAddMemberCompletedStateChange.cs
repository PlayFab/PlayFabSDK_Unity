using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    [NativeTypeName("struct PFLobbyAddMemberCompletedStateChange : PFLobbyStateChange")]
    public unsafe partial struct PFLobbyAddMemberCompletedStateChange
    {
        public PFLobbyStateChange __AnonymousBase_1;

        public int result;

        [NativeTypeName("PFLobbyHandle")]
        public PFLobby* lobby;

        public PFEntityKey localUser;

        public void* asyncContext;
    }
}
