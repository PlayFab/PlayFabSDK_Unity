namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogUpdateDraftItemRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFCatalogCatalogItem *")]
        public PFCatalogCatalogItem* item;

        public byte publish;
    }
}
