namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementBattleNetAccountPlayFabIdPair
    {
        [NativeTypeName("const char *")]
        public sbyte* battleNetAccountId;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
