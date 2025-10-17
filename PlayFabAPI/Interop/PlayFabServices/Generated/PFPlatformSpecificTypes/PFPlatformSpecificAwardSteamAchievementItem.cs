namespace PlayFab.Interop
{
    public unsafe partial struct PFPlatformSpecificAwardSteamAchievementItem
    {
        [NativeTypeName("const char *")]
        public sbyte* achievementName;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        public byte result;
    }
}
