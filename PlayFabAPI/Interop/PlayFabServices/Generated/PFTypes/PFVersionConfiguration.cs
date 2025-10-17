namespace PlayFab.Interop
{
    public partial struct PFVersionConfiguration
    {
        [NativeTypeName("int32_t")]
        public int maxQueryableVersions;

        public PFResetInterval resetInterval;
    }
}
