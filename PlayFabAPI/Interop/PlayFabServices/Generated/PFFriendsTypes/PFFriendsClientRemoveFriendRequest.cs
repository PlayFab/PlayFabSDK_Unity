namespace PlayFab.Interop
{
    public unsafe partial struct PFFriendsClientRemoveFriendRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* friendPlayFabId;
    }
}
