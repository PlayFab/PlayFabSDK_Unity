namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogImage
    {
        [NativeTypeName("const char *")]
        public sbyte* id;

        [NativeTypeName("const char *")]
        public sbyte* tag;

        [NativeTypeName("const char *")]
        public sbyte* type;

        [NativeTypeName("const char *")]
        public sbyte* url;
    }
}
