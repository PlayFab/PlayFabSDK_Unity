namespace PlayFab.Interop
{
    public unsafe partial struct PFInt32DictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("int32_t")]
        public int value;
    }
}
