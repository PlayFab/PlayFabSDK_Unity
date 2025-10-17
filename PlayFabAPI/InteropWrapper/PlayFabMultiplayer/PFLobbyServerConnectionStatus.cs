namespace PlayFab.InteropWrapper.Multiplayer
{
    public enum PFLobbyServerConnectionStatus : uint
    {
        NotConnected = Interop.Multiplayer.PFLobbyServerConnectionStatus.NotConnected,
        Connected = Interop.Multiplayer.PFLobbyServerConnectionStatus.Connected
    }
}
