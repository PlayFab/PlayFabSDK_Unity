namespace PlayFab.Interop
{
    public unsafe partial struct PFLocalizationGetLanguageListResponse
    {
        [NativeTypeName("const char *const *")]
        public sbyte** languageList;

        [NativeTypeName("uint32_t")]
        public uint languageListCount;
    }
}
