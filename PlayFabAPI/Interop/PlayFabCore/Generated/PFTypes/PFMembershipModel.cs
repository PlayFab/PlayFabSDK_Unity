namespace PlayFab.Interop
{
    public unsafe partial struct PFMembershipModel
    {
        public byte isActive;

        [NativeTypeName("time_t")]
        public long membershipExpiration;

        [NativeTypeName("const char *")]
        public sbyte* membershipId;

        [NativeTypeName("const time_t *")]
        public long* overrideExpiration;

        [NativeTypeName("const PFSubscriptionModel *const *")]
        public PFSubscriptionModel** subscriptions;

        [NativeTypeName("uint32_t")]
        public uint subscriptionsCount;
    }
}
