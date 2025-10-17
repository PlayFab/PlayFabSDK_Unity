namespace PlayFab.Interop
{
    public unsafe partial struct PFLeaderboardsGetFriendLeaderboardForEntityRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const PFExternalFriendSources *")]
        public PFExternalFriendSources* externalFriendSources;

        [NativeTypeName("const char *")]
        public sbyte* leaderboardName;

        [NativeTypeName("const uint32_t *")]
        public uint* version;

        [NativeTypeName("const char *")]
        public sbyte* xboxToken;
    }
}
