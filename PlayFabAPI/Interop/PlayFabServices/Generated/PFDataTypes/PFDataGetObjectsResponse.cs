namespace PlayFab.Interop
{
    public unsafe partial struct PFDataGetObjectsResponse
    {
        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const struct PFDataObjectResultDictionaryEntry *")]
        public PFDataObjectResultDictionaryEntry* objects;

        [NativeTypeName("uint32_t")]
        public uint objectsCount;

        [NativeTypeName("int32_t")]
        public int profileVersion;
    }
}
