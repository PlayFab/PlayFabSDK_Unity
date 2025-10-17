namespace PlayFab.Interop
{
    public unsafe partial struct PFEventsGetDataConnectionResponse
    {
        [NativeTypeName("const PFEventsDataConnectionDetails *")]
        public PFEventsDataConnectionDetails* dataConnection;
    }
}
