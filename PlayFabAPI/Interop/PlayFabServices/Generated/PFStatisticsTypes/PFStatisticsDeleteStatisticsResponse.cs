namespace PlayFab.Interop
{
    public unsafe partial struct PFStatisticsDeleteStatisticsResponse
    {
        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;
    }
}
