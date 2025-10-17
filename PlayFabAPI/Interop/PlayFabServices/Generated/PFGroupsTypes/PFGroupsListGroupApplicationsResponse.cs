namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsListGroupApplicationsResponse
    {
        [NativeTypeName("const PFGroupsGroupApplication *const *")]
        public PFGroupsGroupApplication** applications;

        [NativeTypeName("uint32_t")]
        public uint applicationsCount;
    }
}
