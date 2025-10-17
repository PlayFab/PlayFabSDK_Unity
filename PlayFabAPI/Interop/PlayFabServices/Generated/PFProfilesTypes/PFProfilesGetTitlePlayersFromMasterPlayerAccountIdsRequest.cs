namespace PlayFab.Interop
{
    public unsafe partial struct PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *const *")]
        public sbyte** masterPlayerAccountIds;

        [NativeTypeName("uint32_t")]
        public uint masterPlayerAccountIdsCount;

        [NativeTypeName("const char *")]
        public sbyte* titleId;
    }
}
