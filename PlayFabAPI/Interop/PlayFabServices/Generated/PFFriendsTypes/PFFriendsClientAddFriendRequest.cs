namespace PlayFab.Interop
{
    public unsafe partial struct PFFriendsClientAddFriendRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* friendEmail;

        [NativeTypeName("const char *")]
        public sbyte* friendPlayFabId;

        [NativeTypeName("const char *")]
        public sbyte* friendTitleDisplayName;

        [NativeTypeName("const char *")]
        public sbyte* friendUsername;
    }
}
