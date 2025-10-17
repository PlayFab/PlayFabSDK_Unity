namespace PlayFab.Interop
{
    public unsafe partial struct PFTitleDataManagementGetTitleDataRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** keys;

        [NativeTypeName("uint32_t")]
        public uint keysCount;

        [NativeTypeName("const char *")]
        public sbyte* overrideLabel;
    }
}
