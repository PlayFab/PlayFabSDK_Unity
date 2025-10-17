namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementBanInfo
    {
        public byte active;

        [NativeTypeName("const char *")]
        public sbyte* banId;

        [NativeTypeName("const time_t *")]
        public long* created;

        [NativeTypeName("const time_t *")]
        public long* expires;

        [NativeTypeName("const char *")]
        public sbyte* IPAddress;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const char *")]
        public sbyte* reason;

        [NativeTypeName("const char *")]
        public sbyte* userFamilyType;
    }
}
