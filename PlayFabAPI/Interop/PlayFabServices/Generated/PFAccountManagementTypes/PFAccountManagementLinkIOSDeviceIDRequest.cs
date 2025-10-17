namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementLinkIOSDeviceIDRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* deviceId;

        [NativeTypeName("const char *")]
        public sbyte* deviceModel;

        [NativeTypeName("const bool *")]
        public byte* forceLink;

        [NativeTypeName("const char *")]
        public sbyte* OS;
    }
}
