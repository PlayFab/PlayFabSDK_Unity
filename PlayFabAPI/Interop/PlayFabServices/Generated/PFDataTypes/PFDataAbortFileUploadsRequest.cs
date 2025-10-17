namespace PlayFab.Interop
{
    public unsafe partial struct PFDataAbortFileUploadsRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const char *const *")]
        public sbyte** fileNames;

        [NativeTypeName("uint32_t")]
        public uint fileNamesCount;

        [NativeTypeName("const int32_t *")]
        public int* profileVersion;
    }
}
