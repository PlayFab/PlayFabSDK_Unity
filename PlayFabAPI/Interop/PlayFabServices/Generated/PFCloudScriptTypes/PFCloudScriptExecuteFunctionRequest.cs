namespace PlayFab.Interop
{
    public unsafe partial struct PFCloudScriptExecuteFunctionRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const char *")]
        public sbyte* functionName;

        public PFJsonObject functionParameter;

        [NativeTypeName("const bool *")]
        public byte* generatePlayStreamEvent;
    }
}
