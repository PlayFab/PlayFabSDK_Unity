namespace PlayFab.Interop
{
    public unsafe partial struct PFProfilesEntityProfileFileMetadataDictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("const PFProfilesEntityProfileFileMetadata *")]
        public PFProfilesEntityProfileFileMetadata* value;
    }
}
