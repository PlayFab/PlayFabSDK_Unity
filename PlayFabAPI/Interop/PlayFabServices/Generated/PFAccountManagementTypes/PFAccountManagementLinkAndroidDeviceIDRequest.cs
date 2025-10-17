namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementLinkAndroidDeviceIDRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* androidDevice;

        [NativeTypeName("const char *")]
        public sbyte* androidDeviceId;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const bool *")]
        public byte* forceLink;

        [NativeTypeName("const char *")]
        public sbyte* OS;
    }
}
