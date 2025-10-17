namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsResult
    {
        [NativeTypeName("const PFAccountManagementBattleNetAccountPlayFabIdPair *const *")]
        public PFAccountManagementBattleNetAccountPlayFabIdPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
