namespace PlayFab.Interop
{
    public unsafe partial struct PFProfilesSetEntityProfilePolicyRequest
    {
        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const PFProfilesEntityPermissionStatement *const *")]
        public PFProfilesEntityPermissionStatement** statements;

        [NativeTypeName("uint32_t")]
        public uint statementsCount;
    }
}
