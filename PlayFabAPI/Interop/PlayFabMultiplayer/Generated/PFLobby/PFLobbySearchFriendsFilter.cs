using PlayFab.Interop;

namespace PlayFab.Interop.Multiplayer
{
    public unsafe partial struct PFLobbySearchFriendsFilter
    {
        public byte includeSteamFriends;

        public byte includeFacebookFriends;

        [NativeTypeName("const char *")]
        public sbyte* includeXboxFriendsToken;
    }
}
