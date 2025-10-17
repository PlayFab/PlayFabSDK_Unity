using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFMatchmakingStateChangeType : uint
    {
        TicketStatusChanged = 0,
        TicketCompleted = 1,
    }
}
