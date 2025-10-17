namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogDeepLinkFormat
    {
        [NativeTypeName("const char *")]
        public sbyte* format;

        [NativeTypeName("const char *")]
        public sbyte* platform;
    }
}
