namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementRevokeAllBansForUserResult
    {
        [NativeTypeName("const PFAccountManagementBanInfo *const *")]
        public PFAccountManagementBanInfo** banData;

        [NativeTypeName("uint32_t")]
        public uint banDataCount;
    }
}
