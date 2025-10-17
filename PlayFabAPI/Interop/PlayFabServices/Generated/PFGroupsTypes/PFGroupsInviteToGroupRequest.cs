namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsInviteToGroupRequest
    {
        [NativeTypeName("const bool *")]
        public byte* autoAcceptOutstandingApplication;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* group;

        [NativeTypeName("const char *")]
        public sbyte* roleId;
    }
}
