namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementBanRequest
    {
        [NativeTypeName("const uint32_t *")]
        public uint* durationInHours;

        [NativeTypeName("const char *")]
        public sbyte* IPAddress;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const char *")]
        public sbyte* reason;

        [NativeTypeName("const PFAccountManagementUserFamilyType *")]
        public PFAccountManagementUserFamilyType* userFamilyType;
    }
}
