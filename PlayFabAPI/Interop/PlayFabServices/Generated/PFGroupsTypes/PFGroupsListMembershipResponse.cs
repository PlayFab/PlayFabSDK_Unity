namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsListMembershipResponse
    {
        [NativeTypeName("const PFGroupsGroupWithRoles *const *")]
        public PFGroupsGroupWithRoles** groups;

        [NativeTypeName("uint32_t")]
        public uint groupsCount;
    }
}
