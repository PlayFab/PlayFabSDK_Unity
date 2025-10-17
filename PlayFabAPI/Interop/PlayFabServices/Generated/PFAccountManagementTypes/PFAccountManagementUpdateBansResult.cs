namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementUpdateBansResult
    {
        [NativeTypeName("const PFAccountManagementBanInfo *const *")]
        public PFAccountManagementBanInfo** banData;

        [NativeTypeName("uint32_t")]
        public uint banDataCount;
    }
}
