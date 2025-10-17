using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFMultiplayerProtocolType : uint
    {
        Tcp = 0,
        Udp = 1,
    }
}
