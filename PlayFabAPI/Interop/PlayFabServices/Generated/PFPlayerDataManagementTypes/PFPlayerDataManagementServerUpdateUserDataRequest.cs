namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementServerUpdateUserDataRequest
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

        [NativeTypeName("const PFUserDataPermission *")]
        public PFUserDataPermission* permission;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
