namespace PlayFab.Interop
{
    public unsafe partial struct PFEventsSetDataConnectionActiveResponse
    {
        [NativeTypeName("const PFEventsDataConnectionDetails *")]
        public PFEventsDataConnectionDetails* dataConnection;

        public byte wasUpdated;
    }
}
