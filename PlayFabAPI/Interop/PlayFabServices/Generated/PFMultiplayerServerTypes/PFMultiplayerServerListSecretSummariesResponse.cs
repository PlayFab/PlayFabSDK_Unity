namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerListSecretSummariesResponse
    {
        [NativeTypeName("int32_t")]
        public int pageSize;

        [NativeTypeName("const PFMultiplayerServerSecretSummary *const *")]
        public PFMultiplayerServerSecretSummary** secretSummaries;

        [NativeTypeName("uint32_t")]
        public uint secretSummariesCount;

        [NativeTypeName("const char *")]
        public sbyte* skipToken;
    }
}
