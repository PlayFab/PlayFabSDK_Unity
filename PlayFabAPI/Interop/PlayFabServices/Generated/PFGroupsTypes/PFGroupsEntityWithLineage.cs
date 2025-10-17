namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsEntityWithLineage
    {
        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* key;

        [NativeTypeName("const struct PFEntityKeyDictionaryEntry *")]
        public PFEntityKeyDictionaryEntry* lineage;

        [NativeTypeName("uint32_t")]
        public uint lineageCount;
    }
}
