namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementServerUpdatePlayerCustomPropertiesRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const int32_t *")]
        public int* expectedPropertiesVersion;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const PFPlayerDataManagementUpdateProperty *const *")]
        public PFPlayerDataManagementUpdateProperty** properties;

        [NativeTypeName("uint32_t")]
        public uint propertiesCount;
    }
}
