namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerDataManagementGetUserDataRequest
    {
        [NativeTypeName("const uint32_t *")]
        public uint* ifChangedFromDataVersion;

        [NativeTypeName("const char *const *")]
        public sbyte** keys;

        [NativeTypeName("uint32_t")]
        public uint keysCount;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
