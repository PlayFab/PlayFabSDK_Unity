namespace PlayFab.Interop
{
    public unsafe partial struct PFProfilesGetEntityProfilesResponse
    {
        [NativeTypeName("const PFProfilesEntityProfileBody *const *")]
        public PFProfilesEntityProfileBody** profiles;

        [NativeTypeName("uint32_t")]
        public uint profilesCount;
    }
}
