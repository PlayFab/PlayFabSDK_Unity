namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsListGroupMembersResponse
    {
        [NativeTypeName("const PFGroupsEntityMemberRole *const *")]
        public PFGroupsEntityMemberRole** members;

        [NativeTypeName("uint32_t")]
        public uint membersCount;
    }
}
