namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogDeepLink
    {
        [NativeTypeName("const char *")]
        public sbyte* platform;

        [NativeTypeName("const char *")]
        public sbyte* url;
    }
}
