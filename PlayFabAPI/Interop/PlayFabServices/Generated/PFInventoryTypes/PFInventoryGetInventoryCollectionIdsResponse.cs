namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryGetInventoryCollectionIdsResponse
    {
        [NativeTypeName("const char *const *")]
        public sbyte** collectionIds;

        [NativeTypeName("uint32_t")]
        public uint collectionIdsCount;

        [NativeTypeName("const char *")]
        public sbyte* continuationToken;
    }
}
