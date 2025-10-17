namespace PlayFab.Interop
{
    public unsafe partial struct PFCloudScriptScriptExecutionError
    {
        [NativeTypeName("const char *")]
        public sbyte* error;

        [NativeTypeName("const char *")]
        public sbyte* message;

        [NativeTypeName("const char *")]
        public sbyte* stackTrace;
    }
}
