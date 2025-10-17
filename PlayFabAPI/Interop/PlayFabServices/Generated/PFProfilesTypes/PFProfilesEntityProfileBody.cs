namespace PlayFab.Interop
{
    public unsafe partial struct PFProfilesEntityProfileBody
    {
        [NativeTypeName("const char *")]
        public sbyte* avatarUrl;

        [NativeTypeName("time_t")]
        public long created;

        [NativeTypeName("const char *")]
        public sbyte* displayName;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const char *")]
        public sbyte* entityChain;

        [NativeTypeName("const char *const *")]
        public sbyte** experimentVariants;

        [NativeTypeName("uint32_t")]
        public uint experimentVariantsCount;

        [NativeTypeName("const struct PFProfilesEntityProfileFileMetadataDictionaryEntry *")]
        public PFProfilesEntityProfileFileMetadataDictionaryEntry* files;

        [NativeTypeName("uint32_t")]
        public uint filesCount;

        [NativeTypeName("const char *")]
        public sbyte* language;

        [NativeTypeName("const PFEntityLineage *")]
        public PFEntityLineage* lineage;

        [NativeTypeName("const struct PFProfilesEntityDataObjectDictionaryEntry *")]
        public PFProfilesEntityDataObjectDictionaryEntry* objects;

        [NativeTypeName("uint32_t")]
        public uint objectsCount;

        [NativeTypeName("const PFProfilesEntityPermissionStatement *const *")]
        public PFProfilesEntityPermissionStatement** permissions;

        [NativeTypeName("uint32_t")]
        public uint permissionsCount;

        [NativeTypeName("const struct PFEntityStatisticValueDictionaryEntry *")]
        public PFEntityStatisticValueDictionaryEntry* statistics;

        [NativeTypeName("uint32_t")]
        public uint statisticsCount;

        [NativeTypeName("int32_t")]
        public int versionNumber;
    }
}
