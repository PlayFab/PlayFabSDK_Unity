namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromSteamNamesRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** steamNames;

        [NativeTypeName("uint32_t")]
        public uint steamNamesCount;
    }
}
