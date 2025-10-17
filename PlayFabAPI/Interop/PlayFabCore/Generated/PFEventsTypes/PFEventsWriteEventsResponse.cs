namespace PlayFab.Interop
{
    public unsafe partial struct PFEventsWriteEventsResponse
    {
        [NativeTypeName("const char *const *")]
        public sbyte** assignedEventIds;

        [NativeTypeName("uint32_t")]
        public uint assignedEventIdsCount;
    }
}
