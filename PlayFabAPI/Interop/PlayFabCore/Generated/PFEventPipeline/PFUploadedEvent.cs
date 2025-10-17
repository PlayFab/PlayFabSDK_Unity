namespace PlayFab.Interop
{
    public unsafe partial struct PFUploadedEvent
    {
        [NativeTypeName("const char *")]
        public sbyte* clientId;

        [NativeTypeName("const char *")]
        public sbyte* serviceId;
    }
}
