namespace PlayFab.Interop
{
    public unsafe partial struct PFSubscriptionModel
    {
        [NativeTypeName("time_t")]
        public long expiration;

        [NativeTypeName("time_t")]
        public long initialSubscriptionTime;

        public byte isActive;

        [NativeTypeName("const PFSubscriptionProviderStatus *")]
        public PFSubscriptionProviderStatus* status;

        [NativeTypeName("const char *")]
        public sbyte* subscriptionId;

        [NativeTypeName("const char *")]
        public sbyte* subscriptionItemId;

        [NativeTypeName("const char *")]
        public sbyte* subscriptionProvider;
    }
}
