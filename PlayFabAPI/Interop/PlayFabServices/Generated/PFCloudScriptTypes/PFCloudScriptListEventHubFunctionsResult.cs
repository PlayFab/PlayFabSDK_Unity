namespace PlayFab.Interop
{
    public unsafe partial struct PFCloudScriptListEventHubFunctionsResult
    {
        [NativeTypeName("const PFCloudScriptEventHubFunctionModel *const *")]
        public PFCloudScriptEventHubFunctionModel** functions;

        [NativeTypeName("uint32_t")]
        public uint functionsCount;
    }
}
