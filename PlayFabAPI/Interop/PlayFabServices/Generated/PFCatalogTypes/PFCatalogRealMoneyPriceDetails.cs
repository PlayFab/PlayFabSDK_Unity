namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogRealMoneyPriceDetails
    {
        [NativeTypeName("const struct PFInt32DictionaryEntry *")]
        public PFInt32DictionaryEntry* appleAppStorePrices;

        [NativeTypeName("uint32_t")]
        public uint appleAppStorePricesCount;

        [NativeTypeName("const struct PFInt32DictionaryEntry *")]
        public PFInt32DictionaryEntry* googlePlayPrices;

        [NativeTypeName("uint32_t")]
        public uint googlePlayPricesCount;

        [NativeTypeName("const struct PFInt32DictionaryEntry *")]
        public PFInt32DictionaryEntry* microsoftStorePrices;

        [NativeTypeName("uint32_t")]
        public uint microsoftStorePricesCount;

        [NativeTypeName("const struct PFInt32DictionaryEntry *")]
        public PFInt32DictionaryEntry* nintendoEShopPrices;

        [NativeTypeName("uint32_t")]
        public uint nintendoEShopPricesCount;

        [NativeTypeName("const struct PFInt32DictionaryEntry *")]
        public PFInt32DictionaryEntry* playStationStorePrices;

        [NativeTypeName("uint32_t")]
        public uint playStationStorePricesCount;

        [NativeTypeName("const struct PFInt32DictionaryEntry *")]
        public PFInt32DictionaryEntry* steamPrices;

        [NativeTypeName("uint32_t")]
        public uint steamPricesCount;
    }
}
