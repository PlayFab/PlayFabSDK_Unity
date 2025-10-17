namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogModerationState
    {
        [NativeTypeName("const time_t *")]
        public long* lastModifiedDate;

        [NativeTypeName("const char *")]
        public sbyte* reason;

        [NativeTypeName("const PFCatalogModerationStatus *")]
        public PFCatalogModerationStatus* status;
    }
}
