namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsGroupApplication
    {
        [NativeTypeName("const PFGroupsEntityWithLineage *")]
        public PFGroupsEntityWithLineage* entity;

        [NativeTypeName("time_t")]
        public long expires;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* group;
    }
}
