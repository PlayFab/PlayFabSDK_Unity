namespace PlayFab.Interop
{
    public unsafe partial struct PFEventsDataConnectionDetails
    {
        [NativeTypeName("const PFEventsDataConnectionSettings *")]
        public PFEventsDataConnectionSettings* connectionSettings;

        public byte isActive;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const PFEventsDataConnectionStatusDetails *")]
        public PFEventsDataConnectionStatusDetails* status;

        public PFEventsDataConnectionType type;
    }
}
