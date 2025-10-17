namespace PlayFab.Interop
{
    public unsafe partial struct PFFriendsServerGetFriendsListRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFFriendsExternalFriendSources *")]
        public PFFriendsExternalFriendSources* externalPlatformFriends;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const PFPlayerProfileViewConstraints *")]
        public PFPlayerProfileViewConstraints* profileConstraints;

        [NativeTypeName("const char *")]
        public sbyte* xboxToken;
    }
}
