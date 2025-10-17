namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementCustomPropertyDetails
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        public PFJsonObject value;
    }
}
