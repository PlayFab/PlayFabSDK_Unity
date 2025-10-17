namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogGetCatalogConfigResponse
    {
        [NativeTypeName("const PFCatalogCatalogConfig *")]
        public PFCatalogCatalogConfig* config;
    }
}
