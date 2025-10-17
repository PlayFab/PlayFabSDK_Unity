namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetAccountInfoResult
    {
        [NativeTypeName("const PFUserAccountInfo *")]
        public PFUserAccountInfo* accountInfo;
    }
}
