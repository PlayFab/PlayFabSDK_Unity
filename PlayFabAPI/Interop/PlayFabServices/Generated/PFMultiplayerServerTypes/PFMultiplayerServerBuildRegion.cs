namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerBuildRegion
    {
        [NativeTypeName("const PFMultiplayerServerCurrentServerStats *")]
        public PFMultiplayerServerCurrentServerStats* currentServerStats;

        [NativeTypeName("const PFMultiplayerServerDynamicStandbySettings *")]
        public PFMultiplayerServerDynamicStandbySettings* dynamicStandbySettings;

        public byte isAssetReplicationComplete;

        [NativeTypeName("int32_t")]
        public int maxServers;

        [NativeTypeName("const int32_t *")]
        public int* multiplayerServerCountPerVm;

        [NativeTypeName("const char *")]
        public sbyte* region;

        [NativeTypeName("const PFMultiplayerServerScheduledStandbySettings *")]
        public PFMultiplayerServerScheduledStandbySettings* scheduledStandbySettings;

        [NativeTypeName("int32_t")]
        public int standbyServers;

        [NativeTypeName("const char *")]
        public sbyte* status;

        [NativeTypeName("const PFMultiplayerServerAzureVmSize *")]
        public PFMultiplayerServerAzureVmSize* vmSize;
    }
}
