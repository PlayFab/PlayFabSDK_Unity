namespace PlayFab.Interop
{
    public unsafe partial struct PFCloudScriptFunctionExecutionError
    {
        [NativeTypeName("const char *")]
        public sbyte* error;

        [NativeTypeName("const char *")]
        public sbyte* message;

        [NativeTypeName("const char *")]
        public sbyte* stackTrace;
    }
}
