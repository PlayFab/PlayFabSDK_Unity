namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementServerLinkTwitchAccountRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* accessToken;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const bool *")]
        public byte* forceLink;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
