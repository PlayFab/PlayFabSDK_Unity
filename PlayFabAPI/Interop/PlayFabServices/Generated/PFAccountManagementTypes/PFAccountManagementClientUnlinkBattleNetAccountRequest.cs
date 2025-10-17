namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementClientUnlinkBattleNetAccountRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;
    }
}
