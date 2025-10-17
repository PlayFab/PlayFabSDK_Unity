namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayerProfileResult
    {
        [NativeTypeName("const PFPlayerProfileModel *")]
        public PFPlayerProfileModel* playerProfile;
    }
}
