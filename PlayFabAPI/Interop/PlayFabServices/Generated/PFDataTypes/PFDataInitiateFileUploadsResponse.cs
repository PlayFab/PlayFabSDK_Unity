namespace PlayFab.Interop
{
    public unsafe partial struct PFDataInitiateFileUploadsResponse
    {
        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("int32_t")]
        public int profileVersion;

        [NativeTypeName("const PFDataInitiateFileUploadMetadata *const *")]
        public PFDataInitiateFileUploadMetadata** uploadDetails;

        [NativeTypeName("uint32_t")]
        public uint uploadDetailsCount;
    }
}
