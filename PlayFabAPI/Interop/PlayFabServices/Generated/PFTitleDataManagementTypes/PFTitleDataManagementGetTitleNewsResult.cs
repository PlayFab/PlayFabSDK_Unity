namespace PlayFab.Interop
{
    public unsafe partial struct PFTitleDataManagementGetTitleNewsResult
    {
        [NativeTypeName("const PFTitleDataManagementTitleNewsItem *const *")]
        public PFTitleDataManagementTitleNewsItem** news;

        [NativeTypeName("uint32_t")]
        public uint newsCount;
    }
}
