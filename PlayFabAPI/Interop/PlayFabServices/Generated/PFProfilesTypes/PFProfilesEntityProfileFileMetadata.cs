namespace PlayFab.Interop
{
    public unsafe partial struct PFProfilesEntityProfileFileMetadata
    {
        [NativeTypeName("const char *")]
        public sbyte* checksum;

        [NativeTypeName("const char *")]
        public sbyte* fileName;

        [NativeTypeName("time_t")]
        public long lastModified;

        [NativeTypeName("int32_t")]
        public int size;
    }
}
