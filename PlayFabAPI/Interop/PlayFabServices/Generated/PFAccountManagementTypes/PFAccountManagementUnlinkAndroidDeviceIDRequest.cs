namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementUnlinkAndroidDeviceIDRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* androidDeviceId;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;
    }
}
