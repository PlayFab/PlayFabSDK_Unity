namespace PlayFab.Interop
{
    public unsafe partial struct PFSegmentsGetPlayerTagsRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* playfabNamespace;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
