using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFLobbyDisconnectingReason : uint
    {
        NoLocalMembers = 0,
        LobbyDeleted = 1,
        ConnectionInterruption = 2,
        LobbyServerLeft = 3,
    }
}
