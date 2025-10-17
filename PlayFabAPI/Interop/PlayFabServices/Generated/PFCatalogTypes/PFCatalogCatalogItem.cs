namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogCatalogItem
    {
        [NativeTypeName("const PFCatalogCatalogAlternateId *const *")]
        public PFCatalogCatalogAlternateId** alternateIds;

        [NativeTypeName("uint32_t")]
        public uint alternateIdsCount;

        [NativeTypeName("const PFCatalogContent *const *")]
        public PFCatalogContent** contents;

        [NativeTypeName("uint32_t")]
        public uint contentsCount;

        [NativeTypeName("const char *")]
        public sbyte* contentType;

        [NativeTypeName("const time_t *")]
        public long* creationDate;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* creatorEntity;

        [NativeTypeName("const PFCatalogDeepLink *const *")]
        public PFCatalogDeepLink** deepLinks;

        [NativeTypeName("uint32_t")]
        public uint deepLinksCount;

        [NativeTypeName("const char *")]
        public sbyte* defaultStackId;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* description;

        [NativeTypeName("uint32_t")]
        public uint descriptionCount;

        public PFJsonObject displayProperties;

        [NativeTypeName("const char *")]
        public sbyte* displayVersion;

        [NativeTypeName("const time_t *")]
        public long* endDate;

        [NativeTypeName("const char *")]
        public sbyte* eTag;

        [NativeTypeName("const char *")]
        public sbyte* id;

        [NativeTypeName("const PFCatalogImage *const *")]
        public PFCatalogImage** images;

        [NativeTypeName("uint32_t")]
        public uint imagesCount;

        [NativeTypeName("const bool *")]
        public byte* isHidden;

        [NativeTypeName("const PFCatalogCatalogItemReference *const *")]
        public PFCatalogCatalogItemReference** itemReferences;

        [NativeTypeName("uint32_t")]
        public uint itemReferencesCount;

        [NativeTypeName("const struct PFCatalogKeywordSetDictionaryEntry *")]
        public PFCatalogKeywordSetDictionaryEntry* keywords;

        [NativeTypeName("uint32_t")]
        public uint keywordsCount;

        [NativeTypeName("const time_t *")]
        public long* lastModifiedDate;

        [NativeTypeName("const PFCatalogModerationState *")]
        public PFCatalogModerationState* moderation;

        [NativeTypeName("const char *const *")]
        public sbyte** platforms;

        [NativeTypeName("uint32_t")]
        public uint platformsCount;

        [NativeTypeName("const PFCatalogCatalogPriceOptions *")]
        public PFCatalogCatalogPriceOptions* priceOptions;

        [NativeTypeName("const PFCatalogRating *")]
        public PFCatalogRating* rating;

        [NativeTypeName("const PFCatalogRealMoneyPriceDetails *")]
        public PFCatalogRealMoneyPriceDetails* realMoneyPriceDetails;

        [NativeTypeName("const time_t *")]
        public long* startDate;

        [NativeTypeName("const PFCatalogStoreDetails *")]
        public PFCatalogStoreDetails* storeDetails;

        [NativeTypeName("const char *const *")]
        public sbyte** tags;

        [NativeTypeName("uint32_t")]
        public uint tagsCount;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* title;

        [NativeTypeName("uint32_t")]
        public uint titleCount;

        [NativeTypeName("const char *")]
        public sbyte* type;
    }
}
