namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsApplyToGroupResponse
    {
        [NativeTypeName("const PFGroupsEntityWithLineage *")]
        public PFGroupsEntityWithLineage* entity;

        [NativeTypeName("time_t")]
        public long expires;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* group;
    }
}
