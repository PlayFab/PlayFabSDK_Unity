namespace PlayFab.Interop
{
    public unsafe partial struct PFProfilesGetTitlePlayersFromMasterPlayerAccountIdsResponse
    {
        [NativeTypeName("const char *")]
        public sbyte* titleId;

        [NativeTypeName("const struct PFEntityKeyDictionaryEntry *")]
        public PFEntityKeyDictionaryEntry* titlePlayerAccounts;

        [NativeTypeName("uint32_t")]
        public uint titlePlayerAccountsCount;
    }
}
