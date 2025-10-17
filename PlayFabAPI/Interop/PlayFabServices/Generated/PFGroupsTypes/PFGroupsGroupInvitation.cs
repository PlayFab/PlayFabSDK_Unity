namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsGroupInvitation
    {
        [NativeTypeName("time_t")]
        public long expires;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* group;

        [NativeTypeName("const PFGroupsEntityWithLineage *")]
        public PFGroupsEntityWithLineage* invitedByEntity;

        [NativeTypeName("const PFGroupsEntityWithLineage *")]
        public PFGroupsEntityWithLineage* invitedEntity;

        [NativeTypeName("const char *")]
        public sbyte* roleId;
    }
}
