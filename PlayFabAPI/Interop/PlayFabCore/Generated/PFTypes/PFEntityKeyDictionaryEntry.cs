namespace PlayFab.Interop
{
    public unsafe partial struct PFEntityKeyDictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* value;
    }
}
