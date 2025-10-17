namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerListBuildSummariesResponse
    {
        [NativeTypeName("const PFMultiplayerServerBuildSummary *const *")]
        public PFMultiplayerServerBuildSummary** buildSummaries;

        [NativeTypeName("uint32_t")]
        public uint buildSummariesCount;

        [NativeTypeName("int32_t")]
        public int pageSize;

        [NativeTypeName("const char *")]
        public sbyte* skipToken;
    }
}
