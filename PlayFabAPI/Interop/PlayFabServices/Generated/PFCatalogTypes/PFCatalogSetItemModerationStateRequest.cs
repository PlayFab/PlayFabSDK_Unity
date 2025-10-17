namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogSetItemModerationStateRequest
    {
        [NativeTypeName("const PFCatalogCatalogAlternateId *")]
        public PFCatalogCatalogAlternateId* alternateId;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* id;

        [NativeTypeName("const char *")]
        public sbyte* reason;

        [NativeTypeName("const PFCatalogModerationStatus *")]
        public PFCatalogModerationStatus* status;
    }
}
