namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementClientGetPlayerCustomPropertyResult
    {
        [NativeTypeName("int32_t")]
        public int propertiesVersion;

        [NativeTypeName("const PFPlayerDataManagementCustomPropertyDetails *")]
        public PFPlayerDataManagementCustomPropertyDetails* property;
    }
}
