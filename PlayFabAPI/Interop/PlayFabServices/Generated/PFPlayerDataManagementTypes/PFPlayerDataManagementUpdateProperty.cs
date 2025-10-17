namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementUpdateProperty
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        public PFJsonObject value;
    }
}
