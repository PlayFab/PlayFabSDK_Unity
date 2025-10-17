namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetTitlePlayersFromProviderIDsResponse
    {
        [NativeTypeName("const struct PFEntityLineageDictionaryEntry *")]
        public PFEntityLineageDictionaryEntry* titlePlayerAccounts;

        [NativeTypeName("uint32_t")]
        public uint titlePlayerAccountsCount;
    }
}
