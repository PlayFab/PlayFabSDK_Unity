namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementDeletedPropertyDetails
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        public byte wasDeleted;
    }
}
