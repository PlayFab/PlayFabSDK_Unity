namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsGroupBlock
    {
        [NativeTypeName("const PFGroupsEntityWithLineage *")]
        public PFGroupsEntityWithLineage* entity;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* group;
    }
}
