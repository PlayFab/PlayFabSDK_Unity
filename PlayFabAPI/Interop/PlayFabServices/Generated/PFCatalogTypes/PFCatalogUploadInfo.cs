namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogUploadInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* fileName;
    }
}
