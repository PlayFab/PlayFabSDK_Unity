namespace PlayFab.Interop
{
    public unsafe partial struct PFAdCampaignAttributionModel
    {
        [NativeTypeName("time_t")]
        public long attributedAt;

        [NativeTypeName("const char *")]
        public sbyte* campaignId;

        [NativeTypeName("const char *")]
        public sbyte* platform;
    }
}
