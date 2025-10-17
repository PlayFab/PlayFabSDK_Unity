namespace PlayFab.Interop
{
    public unsafe partial struct PFPlatformSpecificAwardSteamAchievementResult
    {
        [NativeTypeName("const PFPlatformSpecificAwardSteamAchievementItem *const *")]
        public PFPlatformSpecificAwardSteamAchievementItem** achievementResults;

        [NativeTypeName("uint32_t")]
        public uint achievementResultsCount;
    }
}
