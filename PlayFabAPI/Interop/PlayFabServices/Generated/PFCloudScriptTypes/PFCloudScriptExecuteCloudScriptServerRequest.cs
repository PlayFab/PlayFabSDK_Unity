namespace PlayFab.Interop
{
    public unsafe partial struct PFCloudScriptExecuteCloudScriptServerRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* functionName;

        public PFJsonObject functionParameter;

        [NativeTypeName("const bool *")]
        public byte* generatePlayStreamEvent;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const PFCloudScriptCloudScriptRevisionOption *")]
        public PFCloudScriptCloudScriptRevisionOption* revisionSelection;

        [NativeTypeName("const int32_t *")]
        public int* specificRevision;
    }
}
