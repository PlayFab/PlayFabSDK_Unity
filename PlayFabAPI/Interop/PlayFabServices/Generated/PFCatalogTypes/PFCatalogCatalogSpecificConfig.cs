namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogCatalogSpecificConfig
    {
        [NativeTypeName("const char *const *")]
        public sbyte** contentTypes;

        [NativeTypeName("uint32_t")]
        public uint contentTypesCount;

        [NativeTypeName("const char *const *")]
        public sbyte** tags;

        [NativeTypeName("uint32_t")]
        public uint tagsCount;
    }
}
