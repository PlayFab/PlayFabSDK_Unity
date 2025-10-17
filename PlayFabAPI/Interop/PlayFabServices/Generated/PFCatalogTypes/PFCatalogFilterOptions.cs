namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogFilterOptions
    {
        [NativeTypeName("const char *")]
        public sbyte* filter;

        [NativeTypeName("const bool *")]
        public byte* includeAllItems;
    }
}
