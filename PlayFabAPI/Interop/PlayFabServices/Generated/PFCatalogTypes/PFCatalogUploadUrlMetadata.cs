namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogUploadUrlMetadata
    {
        [NativeTypeName("const char *")]
        public sbyte* fileName;

        [NativeTypeName("const char *")]
        public sbyte* id;

        [NativeTypeName("const char *")]
        public sbyte* url;
    }
}
