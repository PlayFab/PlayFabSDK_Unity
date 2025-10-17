namespace PlayFab.Interop
{
    public unsafe partial struct PFUserDataRecord
    {
        [NativeTypeName("time_t")]
        public long lastUpdated;

        [NativeTypeName("const PFUserDataPermission *")]
        public PFUserDataPermission* permission;

        [NativeTypeName("const char *")]
        public sbyte* value;
    }
}
