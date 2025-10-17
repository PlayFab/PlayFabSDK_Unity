namespace PlayFab.Interop
{
    public unsafe partial struct PFDataAbortFileUploadsResponse
    {
        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("int32_t")]
        public int profileVersion;
    }
}
