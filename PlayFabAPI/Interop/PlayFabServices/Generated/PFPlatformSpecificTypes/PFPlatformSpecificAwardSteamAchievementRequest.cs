namespace PlayFab.Interop
{
    public unsafe partial struct PFPlatformSpecificAwardSteamAchievementRequest
    {
        [NativeTypeName("const PFPlatformSpecificAwardSteamAchievementItem *const *")]
        public PFPlatformSpecificAwardSteamAchievementItem** achievements;

        [NativeTypeName("uint32_t")]
        public uint achievementsCount;
    }
}
