namespace PlayFab.Interop
{
    public unsafe partial struct PFStringDictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("const char *")]
        public sbyte* value;
    }
}
