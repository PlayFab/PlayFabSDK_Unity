namespace PlayFab.Interop
{
    public unsafe partial struct PFEventsSetDataConnectionResponse
    {
        [NativeTypeName("const PFEventsDataConnectionDetails *")]
        public PFEventsDataConnectionDetails* dataConnection;
    }
}
