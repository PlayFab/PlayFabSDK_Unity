namespace PlayFab.Interop
{
    public unsafe partial struct PFGetPlayerCombinedInfoResultPayload
    {
        [NativeTypeName("const PFUserAccountInfo *")]
        public PFUserAccountInfo* accountInfo;

        [NativeTypeName("const PFCharacterInventory *const *")]
        public PFCharacterInventory** characterInventories;

        [NativeTypeName("uint32_t")]
        public uint characterInventoriesCount;

        [NativeTypeName("const PFCharacterResult *const *")]
        public PFCharacterResult** characterList;

        [NativeTypeName("uint32_t")]
        public uint characterListCount;

        [NativeTypeName("const PFPlayerProfileModel *")]
        public PFPlayerProfileModel* playerProfile;

        [NativeTypeName("const PFStatisticValue *const *")]
        public PFStatisticValue** playerStatistics;

        [NativeTypeName("uint32_t")]
        public uint playerStatisticsCount;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* titleData;

        [NativeTypeName("uint32_t")]
        public uint titleDataCount;

        [NativeTypeName("const struct PFUserDataRecordDictionaryEntry *")]
        public PFUserDataRecordDictionaryEntry* userData;

        [NativeTypeName("uint32_t")]
        public uint userDataCount;

        [NativeTypeName("uint32_t")]
        public uint userDataVersion;

        [NativeTypeName("const PFItemInstance *const *")]
        public PFItemInstance** userInventory;

        [NativeTypeName("uint32_t")]
        public uint userInventoryCount;

        [NativeTypeName("const struct PFUserDataRecordDictionaryEntry *")]
        public PFUserDataRecordDictionaryEntry* userReadOnlyData;

        [NativeTypeName("uint32_t")]
        public uint userReadOnlyDataCount;

        [NativeTypeName("uint32_t")]
        public uint userReadOnlyDataVersion;

        [NativeTypeName("const struct PFInt32DictionaryEntry *")]
        public PFInt32DictionaryEntry* userVirtualCurrency;

        [NativeTypeName("uint32_t")]
        public uint userVirtualCurrencyCount;

        [NativeTypeName("const struct PFVirtualCurrencyRechargeTimeDictionaryEntry *")]
        public PFVirtualCurrencyRechargeTimeDictionaryEntry* userVirtualCurrencyRechargeTimes;

        [NativeTypeName("uint32_t")]
        public uint userVirtualCurrencyRechargeTimesCount;
    }
}
