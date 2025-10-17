namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogUpdateCatalogConfigRequest
    {
        [NativeTypeName("const PFCatalogCatalogConfig *")]
        public PFCatalogCatalogConfig* config;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;
    }
}
