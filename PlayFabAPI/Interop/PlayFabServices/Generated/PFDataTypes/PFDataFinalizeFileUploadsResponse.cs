namespace PlayFab.Interop
{
    public unsafe partial struct PFDataFinalizeFileUploadsResponse
    {
        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const struct PFDataGetFileMetadataDictionaryEntry *")]
        public PFDataGetFileMetadataDictionaryEntry* metadata;

        [NativeTypeName("uint32_t")]
        public uint metadataCount;

        [NativeTypeName("int32_t")]
        public int profileVersion;
    }
}
