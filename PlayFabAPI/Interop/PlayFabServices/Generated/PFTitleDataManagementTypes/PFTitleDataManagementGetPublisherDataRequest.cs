namespace PlayFab.Interop
{
    public unsafe partial struct PFTitleDataManagementGetPublisherDataRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** keys;

        [NativeTypeName("uint32_t")]
        public uint keysCount;
    }
}
