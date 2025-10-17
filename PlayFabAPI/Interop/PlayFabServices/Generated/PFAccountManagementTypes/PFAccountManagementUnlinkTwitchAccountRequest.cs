namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementUnlinkTwitchAccountRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* accessToken;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;
    }
}
