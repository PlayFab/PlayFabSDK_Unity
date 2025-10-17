namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementClientDeletePlayerCustomPropertiesResult
    {
        [NativeTypeName("const PFPlayerDataManagementDeletedPropertyDetails *const *")]
        public PFPlayerDataManagementDeletedPropertyDetails** deletedProperties;

        [NativeTypeName("uint32_t")]
        public uint deletedPropertiesCount;

        [NativeTypeName("int32_t")]
        public int propertiesVersion;
    }
}
