namespace PlayFab.Interop
{
    public unsafe partial struct PFLeaderboardsLinkedStatisticColumn
    {
        [NativeTypeName("const char *")]
        public sbyte* linkedStatisticColumnName;

        [NativeTypeName("const char *")]
        public sbyte* linkedStatisticName;
    }
}
