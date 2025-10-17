namespace PlayFab.Interop
{
    public partial struct PFLeaderboardsLeaderboardEntityRankOnVersionEndConfig
    {
        public PFEventType eventType;

        [NativeTypeName("int32_t")]
        public int rankLimit;
    }
}
