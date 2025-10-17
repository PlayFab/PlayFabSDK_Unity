namespace PlayFab.Interop
{
    public unsafe partial struct PFCloudScriptExecuteFunctionResult
    {
        [NativeTypeName("const PFCloudScriptFunctionExecutionError *")]
        public PFCloudScriptFunctionExecutionError* error;

        [NativeTypeName("int32_t")]
        public int executionTimeMilliseconds;

        [NativeTypeName("const char *")]
        public sbyte* functionName;

        public PFJsonObject functionResult;

        [NativeTypeName("const int32_t *")]
        public int* functionResultSize;

        [NativeTypeName("const bool *")]
        public byte* functionResultTooLarge;
    }
}
