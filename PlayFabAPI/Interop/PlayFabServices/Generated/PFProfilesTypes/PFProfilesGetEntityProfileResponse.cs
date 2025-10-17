namespace PlayFab.Interop
{
    public unsafe partial struct PFProfilesGetEntityProfileResponse
    {
        [NativeTypeName("const PFProfilesEntityProfileBody *")]
        public PFProfilesEntityProfileBody* profile;
    }
}
