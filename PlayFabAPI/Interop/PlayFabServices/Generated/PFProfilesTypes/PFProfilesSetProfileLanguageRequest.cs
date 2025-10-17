namespace PlayFab.Interop
{
    public unsafe partial struct PFProfilesSetProfileLanguageRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const int32_t *")]
        public int* expectedVersion;

        [NativeTypeName("const char *")]
        public sbyte* language;
    }
}
