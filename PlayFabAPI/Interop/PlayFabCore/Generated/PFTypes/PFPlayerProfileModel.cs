namespace PlayFab.Interop
{
    public unsafe partial struct PFPlayerProfileModel
    {
        [NativeTypeName("const PFAdCampaignAttributionModel *const *")]
        public PFAdCampaignAttributionModel** adCampaignAttributions;

        [NativeTypeName("uint32_t")]
        public uint adCampaignAttributionsCount;

        [NativeTypeName("const char *")]
        public sbyte* avatarUrl;

        [NativeTypeName("const time_t *")]
        public long* bannedUntil;

        [NativeTypeName("const PFContactEmailInfoModel *const *")]
        public PFContactEmailInfoModel** contactEmailAddresses;

        [NativeTypeName("uint32_t")]
        public uint contactEmailAddressesCount;

        [NativeTypeName("const time_t *")]
        public long* created;

        [NativeTypeName("const char *")]
        public sbyte* displayName;

        [NativeTypeName("const char *const *")]
        public sbyte** experimentVariants;

        [NativeTypeName("uint32_t")]
        public uint experimentVariantsCount;

        [NativeTypeName("const time_t *")]
        public long* lastLogin;

        [NativeTypeName("const PFLinkedPlatformAccountModel *const *")]
        public PFLinkedPlatformAccountModel** linkedAccounts;

        [NativeTypeName("uint32_t")]
        public uint linkedAccountsCount;

        [NativeTypeName("const PFLocationModel *const *")]
        public PFLocationModel** locations;

        [NativeTypeName("uint32_t")]
        public uint locationsCount;

        [NativeTypeName("const PFMembershipModel *const *")]
        public PFMembershipModel** memberships;

        [NativeTypeName("uint32_t")]
        public uint membershipsCount;

        [NativeTypeName("const PFLoginIdentityProvider *")]
        public PFLoginIdentityProvider* origination;

        [NativeTypeName("const char *")]
        public sbyte* playerId;

        [NativeTypeName("const char *")]
        public sbyte* publisherId;

        [NativeTypeName("const PFPushNotificationRegistrationModel *const *")]
        public PFPushNotificationRegistrationModel** pushNotificationRegistrations;

        [NativeTypeName("uint32_t")]
        public uint pushNotificationRegistrationsCount;

        [NativeTypeName("const PFStatisticModel *const *")]
        public PFStatisticModel** statistics;

        [NativeTypeName("uint32_t")]
        public uint statisticsCount;

        [NativeTypeName("const PFTagModel *const *")]
        public PFTagModel** tags;

        [NativeTypeName("uint32_t")]
        public uint tagsCount;

        [NativeTypeName("const char *")]
        public sbyte* titleId;

        [NativeTypeName("const uint32_t *")]
        public uint* totalValueToDateInUSD;

        [NativeTypeName("const PFValueToDateModel *const *")]
        public PFValueToDateModel** valuesToDate;

        [NativeTypeName("uint32_t")]
        public uint valuesToDateCount;
    }
}
