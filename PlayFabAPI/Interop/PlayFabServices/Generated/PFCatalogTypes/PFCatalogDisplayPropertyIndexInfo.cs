namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogDisplayPropertyIndexInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const PFCatalogDisplayPropertyType *")]
        public PFCatalogDisplayPropertyType* type;
    }
}
