namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerBuildSummary
    {
        [NativeTypeName("const char *")]
        public sbyte* buildId;

        [NativeTypeName("const char *")]
        public sbyte* buildName;

        [NativeTypeName("const time_t *")]
        public long* creationTime;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* metadata;

        [NativeTypeName("uint32_t")]
        public uint metadataCount;

        [NativeTypeName("const PFMultiplayerServerBuildRegion *const *")]
        public PFMultiplayerServerBuildRegion** regionConfigurations;

        [NativeTypeName("uint32_t")]
        public uint regionConfigurationsCount;
    }
}
