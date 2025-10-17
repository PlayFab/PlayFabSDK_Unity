namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementServerGetPlayerCustomPropertyRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const char *")]
        public sbyte* propertyName;
    }
}
