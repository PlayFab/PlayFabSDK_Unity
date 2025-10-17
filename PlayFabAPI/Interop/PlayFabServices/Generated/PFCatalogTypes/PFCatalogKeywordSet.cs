namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogKeywordSet
    {
        [NativeTypeName("const char *const *")]
        public sbyte** values;

        [NativeTypeName("uint32_t")]
        public uint valuesCount;
    }
}
