namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayerCombinedInfoResult
    {
        [NativeTypeName("const PFGetPlayerCombinedInfoResultPayload *")]
        public PFGetPlayerCombinedInfoResultPayload* infoResultPayload;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
