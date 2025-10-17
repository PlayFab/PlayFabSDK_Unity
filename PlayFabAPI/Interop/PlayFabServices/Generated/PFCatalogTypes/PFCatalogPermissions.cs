namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogPermissions
    {
        [NativeTypeName("const char *const *")]
        public sbyte** segmentIds;

        [NativeTypeName("uint32_t")]
        public uint segmentIdsCount;
    }
}
