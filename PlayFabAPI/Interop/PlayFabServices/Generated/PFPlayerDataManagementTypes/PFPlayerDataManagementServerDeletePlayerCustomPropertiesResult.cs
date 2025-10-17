namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementServerDeletePlayerCustomPropertiesResult
    {
        [NativeTypeName("const PFPlayerDataManagementDeletedPropertyDetails *const *")]
        public PFPlayerDataManagementDeletedPropertyDetails** deletedProperties;

        [NativeTypeName("uint32_t")]
        public uint deletedPropertiesCount;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("int32_t")]
        public int propertiesVersion;
    }
}
