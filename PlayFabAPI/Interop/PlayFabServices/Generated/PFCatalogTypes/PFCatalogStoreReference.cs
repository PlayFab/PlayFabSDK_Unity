namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogStoreReference
    {
        [NativeTypeName("const PFCatalogCatalogAlternateId *")]
        public PFCatalogCatalogAlternateId* alternateId;

        [NativeTypeName("const char *")]
        public sbyte* id;
    }
}
