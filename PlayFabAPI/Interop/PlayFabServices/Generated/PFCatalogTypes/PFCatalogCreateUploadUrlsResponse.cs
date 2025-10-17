namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogCreateUploadUrlsResponse
    {
        [NativeTypeName("const PFCatalogUploadUrlMetadata *const *")]
        public PFCatalogUploadUrlMetadata** uploadUrls;

        [NativeTypeName("uint32_t")]
        public uint uploadUrlsCount;
    }
}
