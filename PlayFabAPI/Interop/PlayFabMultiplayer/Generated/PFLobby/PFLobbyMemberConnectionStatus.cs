using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFLobbyMemberConnectionStatus : uint
    {
        NotConnected = 0,
        Connected = 1,
    }
}
