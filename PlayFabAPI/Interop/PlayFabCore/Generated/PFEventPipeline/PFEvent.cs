namespace PlayFab.Interop
{
    public unsafe partial struct PFEvent
    {
        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* entity;

        [NativeTypeName("const char *")]
        public sbyte* eventNamespace;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* clientId;

        [NativeTypeName("const char *")]
        public sbyte* payloadJson;
    }
}
