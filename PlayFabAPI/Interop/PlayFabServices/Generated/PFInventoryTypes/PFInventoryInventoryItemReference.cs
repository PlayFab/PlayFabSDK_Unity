namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryInventoryItemReference
    {
        [NativeTypeName("const PFInventoryAlternateId *")]
        public PFInventoryAlternateId* alternateId;

        [NativeTypeName("const char *")]
        public sbyte* id;

        [NativeTypeName("const char *")]
        public sbyte* stackId;
    }
}
