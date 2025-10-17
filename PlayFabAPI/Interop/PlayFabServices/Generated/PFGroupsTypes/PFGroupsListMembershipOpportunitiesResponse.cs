namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsListMembershipOpportunitiesResponse
    {
        [NativeTypeName("const PFGroupsGroupApplication *const *")]
        public PFGroupsGroupApplication** applications;

        [NativeTypeName("uint32_t")]
        public uint applicationsCount;

        [NativeTypeName("const PFGroupsGroupInvitation *const *")]
        public PFGroupsGroupInvitation** invitations;

        [NativeTypeName("uint32_t")]
        public uint invitationsCount;
    }
}
