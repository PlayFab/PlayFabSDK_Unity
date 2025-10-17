namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementClientListPlayerCustomPropertiesResult
    {
        [NativeTypeName("const PFPlayerDataManagementCustomPropertyDetails *const *")]
        public PFPlayerDataManagementCustomPropertyDetails** properties;

        [NativeTypeName("uint32_t")]
        public uint propertiesCount;

        [NativeTypeName("int32_t")]
        public int propertiesVersion;
    }
}
