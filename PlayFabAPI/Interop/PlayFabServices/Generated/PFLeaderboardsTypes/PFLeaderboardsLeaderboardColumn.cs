namespace PlayFab.Interop
{
    public unsafe partial struct PFLeaderboardsLeaderboardColumn
    {
        [NativeTypeName("const PFLeaderboardsLinkedStatisticColumn *")]
        public PFLeaderboardsLinkedStatisticColumn* linkedStatisticColumn;

        [NativeTypeName("const char *")]
        public sbyte* name;

        public PFLeaderboardsLeaderboardSortDirection sortDirection;
    }
}
