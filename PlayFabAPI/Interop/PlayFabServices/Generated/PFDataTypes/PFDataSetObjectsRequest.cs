namespace PlayFab.Interop
{
    public unsafe partial struct PFDataSetObjectsRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const int32_t *")]
        public int* expectedProfileVersion;

        [NativeTypeName("const PFDataSetObject *const *")]
        public PFDataSetObject** objects;

        [NativeTypeName("uint32_t")]
        public uint objectsCount;
    }
}
