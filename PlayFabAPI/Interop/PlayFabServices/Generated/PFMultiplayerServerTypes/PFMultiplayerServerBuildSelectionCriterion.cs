namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerBuildSelectionCriterion
    {
        [NativeTypeName("const struct PFUint32DictionaryEntry *")]
        public PFUint32DictionaryEntry* buildWeightDistribution;

        [NativeTypeName("uint32_t")]
        public uint buildWeightDistributionCount;
    }
}
