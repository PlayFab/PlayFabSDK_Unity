namespace PlayFab.Interop
{
    public unsafe partial struct PFEventPipelineConfig
    {
        [NativeTypeName("uint32_t *")]
        public uint* maxEventsPerBatch;

        [NativeTypeName("uint32_t *")]
        public uint* maxWaitTimeInSeconds;

        [NativeTypeName("uint32_t *")]
        public uint* pollDelayInMs;

        public HCCompressionLevel* compressionLevel;

        [NativeTypeName("bool *")]
        public byte* retryOnDisconnect;

        [NativeTypeName("size_t *")]
        public ulong* bufferSize;
    }
}
