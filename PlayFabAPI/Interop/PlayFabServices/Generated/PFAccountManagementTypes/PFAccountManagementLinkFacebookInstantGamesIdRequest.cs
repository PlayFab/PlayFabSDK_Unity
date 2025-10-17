namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementLinkFacebookInstantGamesIdRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* facebookInstantGamesSignature;

        [NativeTypeName("const bool *")]
        public byte* forceLink;
    }
}
