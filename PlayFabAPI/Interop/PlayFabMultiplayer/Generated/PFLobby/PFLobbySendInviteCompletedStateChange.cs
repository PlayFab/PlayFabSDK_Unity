using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    [NativeTypeName("struct PFLobbySendInviteCompletedStateChange : PFLobbyStateChange")]
    public unsafe partial struct PFLobbySendInviteCompletedStateChange
    {
        public PFLobbyStateChange __AnonymousBase_1;

        public int result;

        [NativeTypeName("PFLobbyHandle")]
        public PFLobby* lobby;

        public PFEntityKey sender;

        public PFEntityKey invitee;

        public void* asyncContext;
    }
}
