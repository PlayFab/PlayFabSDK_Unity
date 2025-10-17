namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementBanUsersRequest
    {
        [NativeTypeName("const PFAccountManagementBanRequest *const *")]
        public PFAccountManagementBanRequest** bans;

        [NativeTypeName("uint32_t")]
        public uint bansCount;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;
    }
}
