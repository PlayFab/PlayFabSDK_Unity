namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetUserBansResult
    {
        [NativeTypeName("const PFAccountManagementBanInfo *const *")]
        public PFAccountManagementBanInfo** banData;

        [NativeTypeName("uint32_t")]
        public uint banDataCount;
    }
}
