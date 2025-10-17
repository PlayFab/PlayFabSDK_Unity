namespace PlayFab.Interop
{
    public unsafe partial struct PFEventsDataConnectionStatusDetails
    {
        [NativeTypeName("const char *")]
        public sbyte* error;

        [NativeTypeName("const char *")]
        public sbyte* errorMessage;

        [NativeTypeName("const time_t *")]
        public long* mostRecentErrorTime;

        [NativeTypeName("const PFEventsDataConnectionErrorState *")]
        public PFEventsDataConnectionErrorState* state;
    }
}
