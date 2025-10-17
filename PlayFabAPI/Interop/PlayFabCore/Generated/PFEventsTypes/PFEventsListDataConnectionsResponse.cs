namespace PlayFab.Interop
{
    public unsafe partial struct PFEventsListDataConnectionsResponse
    {
        [NativeTypeName("const PFEventsDataConnectionDetails *const *")]
        public PFEventsDataConnectionDetails** dataConnections;

        [NativeTypeName("uint32_t")]
        public uint dataConnectionsCount;
    }
}
