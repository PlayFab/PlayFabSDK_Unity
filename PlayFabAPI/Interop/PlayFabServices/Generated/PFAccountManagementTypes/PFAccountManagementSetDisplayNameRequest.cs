namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementSetDisplayNameRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* displayName;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const int32_t *")]
        public int* expectedVersion;
    }
}
