namespace PlayFab.Interop
{
    public unsafe partial struct PFCloudScriptExecuteCloudScriptResult
    {
        [NativeTypeName("int32_t")]
        public int aPIRequestsIssued;

        [NativeTypeName("const PFCloudScriptScriptExecutionError *")]
        public PFCloudScriptScriptExecutionError* error;

        public double executionTimeSeconds;

        [NativeTypeName("const char *")]
        public sbyte* functionName;

        public PFJsonObject functionResult;

        [NativeTypeName("const bool *")]
        public byte* functionResultTooLarge;

        [NativeTypeName("int32_t")]
        public int httpRequestsIssued;

        [NativeTypeName("const PFCloudScriptLogStatement *const *")]
        public PFCloudScriptLogStatement** logs;

        [NativeTypeName("uint32_t")]
        public uint logsCount;

        [NativeTypeName("const bool *")]
        public byte* logsTooLarge;

        [NativeTypeName("uint32_t")]
        public uint memoryConsumedBytes;

        public double processorTimeSeconds;

        [NativeTypeName("int32_t")]
        public int revision;
    }
}
