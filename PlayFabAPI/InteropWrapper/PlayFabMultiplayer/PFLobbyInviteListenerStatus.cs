namespace PlayFab.InteropWrapper.Multiplayer
{
    public enum PFLobbyInviteListenerStatus : uint
    {
        NotListening = Interop.Multiplayer.PFLobbyInviteListenerStatus.NotListening,
        Listening = Interop.Multiplayer.PFLobbyInviteListenerStatus.Listening,
        NotAuthorized = Interop.Multiplayer.PFLobbyInviteListenerStatus.NotAuthorized,
    }
}
