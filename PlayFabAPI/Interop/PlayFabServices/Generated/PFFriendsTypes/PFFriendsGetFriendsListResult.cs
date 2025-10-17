namespace PlayFab.Interop
{
    public unsafe partial struct PFFriendsGetFriendsListResult
    {
        [NativeTypeName("const PFFriendsFriendInfo *const *")]
        public PFFriendsFriendInfo** friends;

        [NativeTypeName("uint32_t")]
        public uint friendsCount;
    }
}
