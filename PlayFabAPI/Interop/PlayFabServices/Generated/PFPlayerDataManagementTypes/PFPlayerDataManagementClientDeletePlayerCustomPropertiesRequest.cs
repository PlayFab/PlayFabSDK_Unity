namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementClientDeletePlayerCustomPropertiesRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const int32_t *")]
        public int* expectedPropertiesVersion;

        [NativeTypeName("const char *const *")]
        public sbyte** propertyNames;

        [NativeTypeName("uint32_t")]
        public uint propertyNamesCount;
    }
}
