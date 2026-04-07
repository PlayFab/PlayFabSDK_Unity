namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerRequestPartyServiceRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFMultiplayerServerPartyNetworkConfiguration *")]
        public PFMultiplayerServerPartyNetworkConfiguration* networkConfiguration;

        [NativeTypeName("const char *")]
        public sbyte* partyId;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const char *const *")]
        public sbyte** preferredRegions;

        [NativeTypeName("uint32_t")]
        public uint preferredRegionsCount;
    }
}
