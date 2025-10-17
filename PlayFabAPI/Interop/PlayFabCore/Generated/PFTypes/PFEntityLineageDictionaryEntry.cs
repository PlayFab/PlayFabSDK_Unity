namespace PlayFab.Interop
{
    public unsafe partial struct PFEntityLineageDictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("const PFEntityLineage *")]
        public PFEntityLineage* value;
    }
}
