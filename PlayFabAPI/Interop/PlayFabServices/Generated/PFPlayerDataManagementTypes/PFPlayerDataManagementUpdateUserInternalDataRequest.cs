namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementUpdateUserInternalDataRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;

        [NativeTypeName("const char *const *")]
        public sbyte** keysToRemove;

        [NativeTypeName("uint32_t")]
        public uint keysToRemoveCount;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
