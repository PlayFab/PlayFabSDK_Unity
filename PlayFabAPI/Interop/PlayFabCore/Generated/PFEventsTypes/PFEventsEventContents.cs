namespace PlayFab.Interop
{
    public unsafe partial struct PFEventsEventContents
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const char *")]
        public sbyte* eventNamespace;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* originalId;

        [NativeTypeName("const time_t *")]
        public long* originalTimestamp;

        public PFJsonObject payload;

        [NativeTypeName("const char *")]
        public sbyte* payloadJSON;
    }
}
