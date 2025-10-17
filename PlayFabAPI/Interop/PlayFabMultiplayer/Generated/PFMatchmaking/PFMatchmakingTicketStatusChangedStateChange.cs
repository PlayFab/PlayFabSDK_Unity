using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    [NativeTypeName("struct PFMatchmakingTicketStatusChangedStateChange : PFMatchmakingStateChange")]
    public unsafe partial struct PFMatchmakingTicketStatusChangedStateChange
    {
        public PFMatchmakingStateChange __AnonymousBase_1;

        [NativeTypeName("PFMatchmakingTicketHandle")]
        public PFMatchmakingTicket* ticket;
    }
}
