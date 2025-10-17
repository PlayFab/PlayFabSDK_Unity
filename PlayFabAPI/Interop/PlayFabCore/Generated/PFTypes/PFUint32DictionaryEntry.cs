namespace PlayFab.Interop
{
    public unsafe partial struct PFUint32DictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("uint32_t")]
        public uint value;
    }
}
