using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFLobbyMembershipLock : uint
    {
        Unlocked = 0,
        Locked = 1,
    }
}
