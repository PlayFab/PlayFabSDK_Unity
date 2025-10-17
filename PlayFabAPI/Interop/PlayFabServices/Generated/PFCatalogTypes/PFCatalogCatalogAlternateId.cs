namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogCatalogAlternateId
    {
        [NativeTypeName("const char *")]
        public sbyte* type;

        [NativeTypeName("const char *")]
        public sbyte* value;
    }
}
