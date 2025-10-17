namespace PlayFab.Interop
{
    public unsafe partial struct PFLeaderboardsLeaderboardEventEmissionConfig
    {
        [NativeTypeName("const PFLeaderboardsLeaderboardEntityRankOnVersionEndConfig *")]
        public PFLeaderboardsLeaderboardEntityRankOnVersionEndConfig* entityRankOnVersionEndConfig;

        [NativeTypeName("const PFLeaderboardsLeaderboardVersionEndConfig *")]
        public PFLeaderboardsLeaderboardVersionEndConfig* versionEndConfig;
    }
}
