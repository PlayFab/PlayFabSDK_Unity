namespace PlayFab.Interop
{
    public unsafe partial struct PFAuthenticationRegisterPlayFabUserRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* displayName;

        [NativeTypeName("const char *")]
        public sbyte* email;

        [NativeTypeName("const char *")]
        public sbyte* encryptedRequest;

        [NativeTypeName("const PFGetPlayerCombinedInfoRequestParams *")]
        public PFGetPlayerCombinedInfoRequestParams* infoRequestParameters;

        [NativeTypeName("const char *")]
        public sbyte* password;

        [NativeTypeName("const char *")]
        public sbyte* playerSecret;

        [NativeTypeName("const bool *")]
        public byte* requireBothUsernameAndEmail;

        [NativeTypeName("const char *")]
        public sbyte* titleId;

        [NativeTypeName("const char *")]
        public sbyte* username;
    }
}
