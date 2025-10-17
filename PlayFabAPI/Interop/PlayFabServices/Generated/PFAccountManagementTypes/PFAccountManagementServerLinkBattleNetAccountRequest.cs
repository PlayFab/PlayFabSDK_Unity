namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementServerLinkBattleNetAccountRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const bool *")]
        public byte* forceLink;

        [NativeTypeName("const char *")]
        public sbyte* identityToken;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
