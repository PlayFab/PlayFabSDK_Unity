namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementServerGetPlayerCustomPropertyResult
    {
        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("int32_t")]
        public int propertiesVersion;

        [NativeTypeName("const PFPlayerDataManagementCustomPropertyDetails *")]
        public PFPlayerDataManagementCustomPropertyDetails* property;
    }
}
