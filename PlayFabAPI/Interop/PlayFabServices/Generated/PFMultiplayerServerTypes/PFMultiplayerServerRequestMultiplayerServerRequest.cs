namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerRequestMultiplayerServerRequest
    {
        [NativeTypeName("const PFMultiplayerServerBuildAliasParams *")]
        public PFMultiplayerServerBuildAliasParams* buildAliasParams;

        [NativeTypeName("const char *")]
        public sbyte* buildId;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *const *")]
        public sbyte** initialPlayers;

        [NativeTypeName("uint32_t")]
        public uint initialPlayersCount;

        [NativeTypeName("const char *const *")]
        public sbyte** preferredRegions;

        [NativeTypeName("uint32_t")]
        public uint preferredRegionsCount;

        [NativeTypeName("const char *")]
        public sbyte* sessionCookie;

        [NativeTypeName("const char *")]
        public sbyte* sessionId;
    }
}
