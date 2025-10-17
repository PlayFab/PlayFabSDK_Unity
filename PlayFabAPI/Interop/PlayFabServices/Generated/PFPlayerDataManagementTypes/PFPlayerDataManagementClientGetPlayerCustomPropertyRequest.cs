namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementClientGetPlayerCustomPropertyRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* propertyName;
    }
}
