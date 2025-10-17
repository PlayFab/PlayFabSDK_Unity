namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogGetItemContainersResponse
    {
        [NativeTypeName("const PFCatalogCatalogItem *const *")]
        public PFCatalogCatalogItem** containers;

        [NativeTypeName("uint32_t")]
        public uint containersCount;

        [NativeTypeName("const char *")]
        public sbyte* continuationToken;
    }
}
