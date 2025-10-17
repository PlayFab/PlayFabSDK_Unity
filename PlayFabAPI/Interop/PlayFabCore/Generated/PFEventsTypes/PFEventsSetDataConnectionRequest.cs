namespace PlayFab.Interop
{
    public unsafe partial struct PFEventsSetDataConnectionRequest
    {
        [NativeTypeName("const PFEventsDataConnectionSettings *")]
        public PFEventsDataConnectionSettings* connectionSettings;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        public byte isActive;

        [NativeTypeName("const char *")]
        public sbyte* name;

        public PFEventsDataConnectionType type;
    }
}
