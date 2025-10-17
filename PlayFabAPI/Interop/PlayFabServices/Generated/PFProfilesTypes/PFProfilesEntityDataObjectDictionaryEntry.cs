namespace PlayFab.Interop
{
    public unsafe partial struct PFProfilesEntityDataObjectDictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("const PFProfilesEntityDataObject *")]
        public PFProfilesEntityDataObject* value;
    }
}
