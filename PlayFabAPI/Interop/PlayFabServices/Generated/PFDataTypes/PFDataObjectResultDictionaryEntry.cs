namespace PlayFab.Interop
{
    public unsafe partial struct PFDataObjectResultDictionaryEntry
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("const PFDataObjectResult *")]
        public PFDataObjectResult* value;
    }
}
