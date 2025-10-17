namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogGetItemPublishStatusResponse
    {
        [NativeTypeName("const PFCatalogPublishResult *")]
        public PFCatalogPublishResult* result;

        [NativeTypeName("const char *")]
        public sbyte* statusMessage;
    }
}
