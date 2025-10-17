namespace PlayFab.Interop
{
    public unsafe partial struct PFSegmentsGetPlayersInSegmentResult
    {
        [NativeTypeName("const char *")]
        public sbyte* continuationToken;

        [NativeTypeName("const PFSegmentsPlayerProfile *const *")]
        public PFSegmentsPlayerProfile** playerProfiles;

        [NativeTypeName("uint32_t")]
        public uint playerProfilesCount;

        [NativeTypeName("int32_t")]
        public int profilesInSegment;
    }
}
