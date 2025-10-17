namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementLinkXboxIdRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const bool *")]
        public byte* forceLink;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const char *")]
        public sbyte* sandbox;

        [NativeTypeName("const char *")]
        public sbyte* xboxId;
    }
}
