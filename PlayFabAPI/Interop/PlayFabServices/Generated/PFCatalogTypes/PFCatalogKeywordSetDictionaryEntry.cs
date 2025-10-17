namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogKeywordSetDictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("const PFCatalogKeywordSet *")]
        public PFCatalogKeywordSet* value;
    }
}
