namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogCatalogConfig
    {
        [NativeTypeName("const PFEntityKey *const *")]
        public PFEntityKey** adminEntities;

        [NativeTypeName("uint32_t")]
        public uint adminEntitiesCount;

        [NativeTypeName("const PFCatalogCatalogSpecificConfig *")]
        public PFCatalogCatalogSpecificConfig* catalog;

        [NativeTypeName("const PFCatalogDeepLinkFormat *const *")]
        public PFCatalogDeepLinkFormat** deepLinkFormats;

        [NativeTypeName("uint32_t")]
        public uint deepLinkFormatsCount;

        [NativeTypeName("const PFCatalogDisplayPropertyIndexInfo *const *")]
        public PFCatalogDisplayPropertyIndexInfo** displayPropertyIndexInfos;

        [NativeTypeName("uint32_t")]
        public uint displayPropertyIndexInfosCount;

        [NativeTypeName("const PFCatalogFileConfig *")]
        public PFCatalogFileConfig* file;

        [NativeTypeName("const PFCatalogImageConfig *")]
        public PFCatalogImageConfig* image;

        public byte isCatalogEnabled;

        [NativeTypeName("const char *const *")]
        public sbyte** platforms;

        [NativeTypeName("uint32_t")]
        public uint platformsCount;

        [NativeTypeName("const PFCatalogReviewConfig *")]
        public PFCatalogReviewConfig* review;

        [NativeTypeName("const PFEntityKey *const *")]
        public PFEntityKey** reviewerEntities;

        [NativeTypeName("uint32_t")]
        public uint reviewerEntitiesCount;

        [NativeTypeName("const PFCatalogUserGeneratedContentSpecificConfig *")]
        public PFCatalogUserGeneratedContentSpecificConfig* userGeneratedContent;
    }
}
