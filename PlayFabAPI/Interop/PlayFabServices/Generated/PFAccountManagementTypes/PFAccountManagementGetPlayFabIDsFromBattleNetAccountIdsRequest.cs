namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromBattleNetAccountIdsRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** battleNetAccountIds;

        [NativeTypeName("uint32_t")]
        public uint battleNetAccountIdsCount;
    }
}
