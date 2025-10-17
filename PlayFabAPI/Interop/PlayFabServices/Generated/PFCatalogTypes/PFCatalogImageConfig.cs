namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogImageConfig
    {
        [NativeTypeName("const char *const *")]
        public sbyte** tags;

        [NativeTypeName("uint32_t")]
        public uint tagsCount;
    }
}
