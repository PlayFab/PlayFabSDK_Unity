namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogCreateUploadUrlsRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFCatalogUploadInfo *const *")]
        public PFCatalogUploadInfo** files;

        [NativeTypeName("uint32_t")]
        public uint filesCount;
    }
}
