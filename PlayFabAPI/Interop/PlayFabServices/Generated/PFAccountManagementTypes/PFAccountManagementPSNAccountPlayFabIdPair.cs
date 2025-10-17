namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementPSNAccountPlayFabIdPair
    {
        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const char *")]
        public sbyte* PSNAccountId;
    }
}
