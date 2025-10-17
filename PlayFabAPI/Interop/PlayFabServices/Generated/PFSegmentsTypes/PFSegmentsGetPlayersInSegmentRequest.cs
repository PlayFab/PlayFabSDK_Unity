namespace PlayFab.Interop
{
    public unsafe partial struct PFSegmentsGetPlayersInSegmentRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* continuationToken;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const bool *")]
        public byte* getProfilesAsync;

        [NativeTypeName("const uint32_t *")]
        public uint* maxBatchSize;

        [NativeTypeName("const uint32_t *")]
        public uint* secondsToLive;

        [NativeTypeName("const char *")]
        public sbyte* segmentId;
    }
}
