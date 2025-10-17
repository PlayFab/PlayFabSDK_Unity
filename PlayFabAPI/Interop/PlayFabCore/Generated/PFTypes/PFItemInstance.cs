namespace PlayFab.Interop
{
    public unsafe partial struct PFItemInstance
    {
        [NativeTypeName("const char *")]
        public sbyte* annotation;

        [NativeTypeName("const char *const *")]
        public sbyte** bundleContents;

        [NativeTypeName("uint32_t")]
        public uint bundleContentsCount;

        [NativeTypeName("const char *")]
        public sbyte* bundleParent;

        [NativeTypeName("const char *")]
        public sbyte* catalogVersion;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customData;

        [NativeTypeName("uint32_t")]
        public uint customDataCount;

        [NativeTypeName("const char *")]
        public sbyte* displayName;

        [NativeTypeName("const time_t *")]
        public long* expiration;

        [NativeTypeName("const char *")]
        public sbyte* itemClass;

        [NativeTypeName("const char *")]
        public sbyte* itemId;

        [NativeTypeName("const char *")]
        public sbyte* itemInstanceId;

        [NativeTypeName("const time_t *")]
        public long* purchaseDate;

        [NativeTypeName("const int32_t *")]
        public int* remainingUses;

        [NativeTypeName("const char *")]
        public sbyte* unitCurrency;

        [NativeTypeName("uint32_t")]
        public uint unitPrice;

        [NativeTypeName("const int32_t *")]
        public int* usesIncrementedBy;
    }
}
