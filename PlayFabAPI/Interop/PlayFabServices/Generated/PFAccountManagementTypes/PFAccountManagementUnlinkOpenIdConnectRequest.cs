namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementUnlinkOpenIdConnectRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* connectionId;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;
    }
}
