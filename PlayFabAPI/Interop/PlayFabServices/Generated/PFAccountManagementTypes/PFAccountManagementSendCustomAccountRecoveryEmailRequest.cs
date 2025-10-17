namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementSendCustomAccountRecoveryEmailRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* email;

        [NativeTypeName("const char *")]
        public sbyte* emailTemplateId;

        [NativeTypeName("const char *")]
        public sbyte* username;
    }
}
