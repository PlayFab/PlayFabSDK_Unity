namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementServerUpdatePlayerCustomPropertiesResult
    {
        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("int32_t")]
        public int propertiesVersion;
    }
}
