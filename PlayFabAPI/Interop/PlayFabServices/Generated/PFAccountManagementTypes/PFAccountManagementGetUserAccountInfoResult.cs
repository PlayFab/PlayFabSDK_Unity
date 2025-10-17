namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetUserAccountInfoResult
    {
        [NativeTypeName("const PFUserAccountInfo *")]
        public PFUserAccountInfo* userInfo;
    }
}
