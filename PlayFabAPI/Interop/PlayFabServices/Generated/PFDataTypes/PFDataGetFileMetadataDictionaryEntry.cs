namespace PlayFab.Interop
{
    public unsafe partial struct PFDataGetFileMetadataDictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("const PFDataGetFileMetadata *")]
        public PFDataGetFileMetadata* value;
    }
}
