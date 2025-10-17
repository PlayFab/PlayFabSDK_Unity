namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsListGroupInvitationsResponse
    {
        [NativeTypeName("const PFGroupsGroupInvitation *const *")]
        public PFGroupsGroupInvitation** invitations;

        [NativeTypeName("uint32_t")]
        public uint invitationsCount;
    }
}
