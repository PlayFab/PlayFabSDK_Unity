namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementServerListPlayerCustomPropertiesResult
    {
        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const PFPlayerDataManagementCustomPropertyDetails *const *")]
        public PFPlayerDataManagementCustomPropertyDetails** properties;

        [NativeTypeName("uint32_t")]
        public uint propertiesCount;

        [NativeTypeName("int32_t")]
        public int propertiesVersion;
    }
}
