namespace PlayFab.Interop
{
    public unsafe partial struct PFGetPlayerCombinedInfoRequestParams
    {
        public byte getCharacterInventories;

        public byte getCharacterList;

        public byte getPlayerProfile;

        public byte getPlayerStatistics;

        public byte getTitleData;

        public byte getUserAccountInfo;

        public byte getUserData;

        public byte getUserInventory;

        public byte getUserReadOnlyData;

        public byte getUserVirtualCurrency;

        [NativeTypeName("const char *const *")]
        public sbyte** playerStatisticNames;

        [NativeTypeName("uint32_t")]
        public uint playerStatisticNamesCount;

        [NativeTypeName("const PFPlayerProfileViewConstraints *")]
        public PFPlayerProfileViewConstraints* profileConstraints;

        [NativeTypeName("const char *const *")]
        public sbyte** titleDataKeys;

        [NativeTypeName("uint32_t")]
        public uint titleDataKeysCount;

        [NativeTypeName("const char *const *")]
        public sbyte** userDataKeys;

        [NativeTypeName("uint32_t")]
        public uint userDataKeysCount;

        [NativeTypeName("const char *const *")]
        public sbyte** userReadOnlyDataKeys;

        [NativeTypeName("uint32_t")]
        public uint userReadOnlyDataKeysCount;
    }
}
