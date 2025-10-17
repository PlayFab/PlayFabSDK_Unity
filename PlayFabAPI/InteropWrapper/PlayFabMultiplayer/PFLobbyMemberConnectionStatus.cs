namespace PlayFab.InteropWrapper.Multiplayer
{
    public enum PFLobbyMemberConnectionStatus : uint
    {
        NotConnected = Interop.Multiplayer.PFLobbyMemberConnectionStatus.NotConnected,
        Connected = Interop.Multiplayer.PFLobbyMemberConnectionStatus.Connected
    }
}
