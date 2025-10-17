namespace PlayFab.Interop
{
    public unsafe partial struct PFSegmentsPlayerLocationDictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("const PFSegmentsPlayerLocation *")]
        public PFSegmentsPlayerLocation* value;
    }
}
