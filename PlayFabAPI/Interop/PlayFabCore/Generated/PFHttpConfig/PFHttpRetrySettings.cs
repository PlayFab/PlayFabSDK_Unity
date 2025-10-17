namespace PlayFab.Interop
{
    public partial struct PFHttpRetrySettings
    {
        public byte allowRetry;

        [NativeTypeName("uint32_t")]
        public uint minimumRetryDelayInSeconds;

        [NativeTypeName("uint32_t")]
        public uint timeoutWindowInSeconds;
    }
}
