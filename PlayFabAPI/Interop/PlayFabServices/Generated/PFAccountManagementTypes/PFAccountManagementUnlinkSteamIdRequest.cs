namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementUnlinkSteamIdRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
