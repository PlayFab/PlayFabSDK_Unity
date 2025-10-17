namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerUploadSecretRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const bool *")]
        public byte* forceUpdate;

        [NativeTypeName("const PFMultiplayerServerSecret *")]
        public PFMultiplayerServerSecret* gameSecret;
    }
}
