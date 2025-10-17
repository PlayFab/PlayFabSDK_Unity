namespace PlayFab.Interop
{
    public unsafe partial struct PFCloudScriptEventHubFunctionModel
    {
        [NativeTypeName("const char *")]
        public sbyte* connectionString;

        [NativeTypeName("const char *")]
        public sbyte* eventHubName;

        [NativeTypeName("const char *")]
        public sbyte* functionName;
    }
}
