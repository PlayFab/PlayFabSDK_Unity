namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementUpdateBansRequest
    {
        [NativeTypeName("const PFAccountManagementUpdateBanRequest *const *")]
        public PFAccountManagementUpdateBanRequest** bans;

        [NativeTypeName("uint32_t")]
        public uint bansCount;
    }
}
