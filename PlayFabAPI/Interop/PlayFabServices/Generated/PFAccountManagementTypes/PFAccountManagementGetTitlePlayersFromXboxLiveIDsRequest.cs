namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetTitlePlayersFromXboxLiveIDsRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* sandbox;

        [NativeTypeName("const char *")]
        public sbyte* titleId;

        [NativeTypeName("const char *const *")]
        public sbyte** xboxLiveIds;

        [NativeTypeName("uint32_t")]
        public uint xboxLiveIdsCount;
    }
}
