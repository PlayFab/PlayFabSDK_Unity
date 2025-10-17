namespace PlayFab.Interop
{
    public unsafe partial struct PFUserBattleNetInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* battleNetAccountId;

        [NativeTypeName("const char *")]
        public sbyte* battleNetBattleTag;
    }
}
