namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementClientUnlinkFacebookAccountRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;
    }
}
