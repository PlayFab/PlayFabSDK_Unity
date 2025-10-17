namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementUpdateBanRequest
    {
        [NativeTypeName("const bool *")]
        public byte* active;

        [NativeTypeName("const char *")]
        public sbyte* banId;

        [NativeTypeName("const time_t *")]
        public long* expires;

        [NativeTypeName("const char *")]
        public sbyte* IPAddress;

        [NativeTypeName("const bool *")]
        public byte* permanent;

        [NativeTypeName("const char *")]
        public sbyte* reason;

        [NativeTypeName("const PFAccountManagementUserFamilyType *")]
        public PFAccountManagementUserFamilyType* userFamilyType;
    }
}
