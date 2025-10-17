namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsListGroupBlocksResponse
    {
        [NativeTypeName("const PFGroupsGroupBlock *const *")]
        public PFGroupsGroupBlock** blockedEntities;

        [NativeTypeName("uint32_t")]
        public uint blockedEntitiesCount;
    }
}
