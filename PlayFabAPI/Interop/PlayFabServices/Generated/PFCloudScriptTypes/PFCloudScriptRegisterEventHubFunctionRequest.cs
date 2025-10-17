namespace PlayFab.Interop
{
    public unsafe partial struct PFCloudScriptRegisterEventHubFunctionRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* connectionString;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* eventHubName;

        [NativeTypeName("const char *")]
        public sbyte* functionName;
    }
}
