namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerDynamicStandbySettings
    {
        [NativeTypeName("const PFMultiplayerServerDynamicStandbyThreshold *const *")]
        public PFMultiplayerServerDynamicStandbyThreshold** dynamicFloorMultiplierThresholds;

        [NativeTypeName("uint32_t")]
        public uint dynamicFloorMultiplierThresholdsCount;

        public byte isEnabled;

        [NativeTypeName("const int32_t *")]
        public int* rampDownSeconds;
    }
}
