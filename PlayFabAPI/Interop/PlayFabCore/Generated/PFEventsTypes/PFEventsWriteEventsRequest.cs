namespace PlayFab.Interop
{
    public unsafe partial struct PFEventsWriteEventsRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEventsEventContents *const *")]
        public PFEventsEventContents** events;

        [NativeTypeName("uint32_t")]
        public uint eventsCount;
    }
}
