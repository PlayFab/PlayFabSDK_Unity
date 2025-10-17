namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogContent
    {
        [NativeTypeName("const char *")]
        public sbyte* id;

        [NativeTypeName("const char *")]
        public sbyte* maxClientVersion;

        [NativeTypeName("const char *")]
        public sbyte* minClientVersion;

        [NativeTypeName("const char *const *")]
        public sbyte** tags;

        [NativeTypeName("uint32_t")]
        public uint tagsCount;

        [NativeTypeName("const char *")]
        public sbyte* type;

        [NativeTypeName("const char *")]
        public sbyte* url;
    }
}
