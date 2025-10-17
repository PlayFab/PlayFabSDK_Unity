namespace PlayFab.Interop
{
    public unsafe partial struct PFEventsDataConnectionFabricKQLSettings
    {
        [NativeTypeName("const char *")]
        public sbyte* clusterUri;

        [NativeTypeName("const char *")]
        public sbyte* database;

        [NativeTypeName("const char *")]
        public sbyte* table;
    }
}
