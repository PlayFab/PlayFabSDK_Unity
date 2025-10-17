namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerListQosServersForTitleRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const bool *")]
        public byte* includeAllRegions;

        [NativeTypeName("const char *")]
        public sbyte* routingPreference;
    }
}
