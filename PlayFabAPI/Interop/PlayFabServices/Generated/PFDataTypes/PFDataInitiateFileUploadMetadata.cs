namespace PlayFab.Interop
{
    public unsafe partial struct PFDataInitiateFileUploadMetadata
    {
        [NativeTypeName("const char *")]
        public sbyte* fileName;

        [NativeTypeName("const char *")]
        public sbyte* uploadUrl;
    }
}
