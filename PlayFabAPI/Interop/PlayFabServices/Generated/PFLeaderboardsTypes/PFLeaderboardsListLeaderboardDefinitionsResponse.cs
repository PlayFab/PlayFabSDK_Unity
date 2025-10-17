namespace PlayFab.Interop
{
    public unsafe partial struct PFLeaderboardsListLeaderboardDefinitionsResponse
    {
        [NativeTypeName("const PFLeaderboardsLeaderboardDefinition *const *")]
        public PFLeaderboardsLeaderboardDefinition** leaderboardDefinitions;

        [NativeTypeName("uint32_t")]
        public uint leaderboardDefinitionsCount;
    }
}
