namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryAlternateId
    {
        [NativeTypeName("const char *")]
        public sbyte* type;

        [NativeTypeName("const char *")]
        public sbyte* value;
    }
}
