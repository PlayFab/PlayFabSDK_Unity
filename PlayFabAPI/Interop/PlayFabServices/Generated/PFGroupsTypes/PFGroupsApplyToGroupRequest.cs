namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsApplyToGroupRequest
    {
        [NativeTypeName("const bool *")]
        public byte* autoAcceptOutstandingInvite;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* group;
    }
}
