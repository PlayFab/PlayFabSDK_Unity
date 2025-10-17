namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromFacebookInstantGamesIdsRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** facebookInstantGamesIds;

        [NativeTypeName("uint32_t")]
        public uint facebookInstantGamesIdsCount;
    }
}
