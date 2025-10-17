namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsResult
    {
        [NativeTypeName("const PFAccountManagementFacebookInstantGamesPlayFabIdPair *const *")]
        public PFAccountManagementFacebookInstantGamesPlayFabIdPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
