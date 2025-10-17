namespace PlayFab.Interop
{
    public unsafe partial struct PFSegmentsPlayerProfile
    {
        [NativeTypeName("const PFSegmentsAdCampaignAttribution *const *")]
        public PFSegmentsAdCampaignAttribution** adCampaignAttributions;

        [NativeTypeName("uint32_t")]
        public uint adCampaignAttributionsCount;

        [NativeTypeName("const char *")]
        public sbyte* avatarUrl;

        [NativeTypeName("const time_t *")]
        public long* bannedUntil;

        [NativeTypeName("const PFSegmentsChurnRiskLevel *")]
        public PFSegmentsChurnRiskLevel* churnPrediction;

        [NativeTypeName("const PFSegmentsContactEmailInfo *const *")]
        public PFSegmentsContactEmailInfo** contactEmailAddresses;

        [NativeTypeName("uint32_t")]
        public uint contactEmailAddressesCount;

        [NativeTypeName("const time_t *")]
        public long* created;

        public PFJsonObject customProperties;

        [NativeTypeName("const char *")]
        public sbyte* displayName;

        [NativeTypeName("const time_t *")]
        public long* lastLogin;

        [NativeTypeName("const PFSegmentsPlayerLinkedAccount *const *")]
        public PFSegmentsPlayerLinkedAccount** linkedAccounts;

        [NativeTypeName("uint32_t")]
        public uint linkedAccountsCount;

        [NativeTypeName("const struct PFSegmentsPlayerLocationDictionaryEntry *")]
        public PFSegmentsPlayerLocationDictionaryEntry* locations;

        [NativeTypeName("uint32_t")]
        public uint locationsCount;

        [NativeTypeName("const PFLoginIdentityProvider *")]
        public PFLoginIdentityProvider* origination;

        [NativeTypeName("const char *const *")]
        public sbyte** playerExperimentVariants;

        [NativeTypeName("uint32_t")]
        public uint playerExperimentVariantsCount;

        [NativeTypeName("const char *")]
        public sbyte* playerId;

        [NativeTypeName("const PFSegmentsPlayerStatistic *const *")]
        public PFSegmentsPlayerStatistic** playerStatistics;

        [NativeTypeName("uint32_t")]
        public uint playerStatisticsCount;

        [NativeTypeName("const char *")]
        public sbyte* publisherId;

        [NativeTypeName("const PFSegmentsPushNotificationRegistration *const *")]
        public PFSegmentsPushNotificationRegistration** pushNotificationRegistrations;

        [NativeTypeName("uint32_t")]
        public uint pushNotificationRegistrationsCount;

        [NativeTypeName("const struct PFInt32DictionaryEntry *")]
        public PFInt32DictionaryEntry* statistics;

        [NativeTypeName("uint32_t")]
        public uint statisticsCount;

        [NativeTypeName("const char *const *")]
        public sbyte** tags;

        [NativeTypeName("uint32_t")]
        public uint tagsCount;

        [NativeTypeName("const char *")]
        public sbyte* titleId;

        [NativeTypeName("const uint32_t *")]
        public uint* totalValueToDateInUSD;

        [NativeTypeName("const struct PFUint32DictionaryEntry *")]
        public PFUint32DictionaryEntry* valuesToDate;

        [NativeTypeName("uint32_t")]
        public uint valuesToDateCount;

        [NativeTypeName("const struct PFInt32DictionaryEntry *")]
        public PFInt32DictionaryEntry* virtualCurrencyBalances;

        [NativeTypeName("uint32_t")]
        public uint virtualCurrencyBalancesCount;
    }
}
