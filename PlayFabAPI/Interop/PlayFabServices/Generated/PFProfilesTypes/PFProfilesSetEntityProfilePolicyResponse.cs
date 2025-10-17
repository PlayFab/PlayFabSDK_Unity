namespace PlayFab.Interop
{
    public unsafe partial struct PFProfilesSetEntityProfilePolicyResponse
    {
        [NativeTypeName("const PFProfilesEntityPermissionStatement *const *")]
        public PFProfilesEntityPermissionStatement** permissions;

        [NativeTypeName("uint32_t")]
        public uint permissionsCount;
    }
}
