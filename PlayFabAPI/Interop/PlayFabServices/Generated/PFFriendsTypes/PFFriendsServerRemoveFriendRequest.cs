namespace PlayFab.Interop
{
    public unsafe partial struct PFFriendsServerRemoveFriendRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* friendPlayFabId;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
