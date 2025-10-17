namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogReview
    {
        [NativeTypeName("const struct PFInt32DictionaryEntry *")]
        public PFInt32DictionaryEntry* categoryRatings;

        [NativeTypeName("uint32_t")]
        public uint categoryRatingsCount;

        [NativeTypeName("int32_t")]
        public int helpfulNegative;

        [NativeTypeName("int32_t")]
        public int helpfulPositive;

        public byte isInstalled;

        [NativeTypeName("const char *")]
        public sbyte* itemId;

        [NativeTypeName("const char *")]
        public sbyte* itemVersion;

        [NativeTypeName("const char *")]
        public sbyte* locale;

        [NativeTypeName("int32_t")]
        public int rating;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* reviewerEntity;

        [NativeTypeName("const char *")]
        public sbyte* reviewId;

        [NativeTypeName("const char *")]
        public sbyte* reviewText;

        [NativeTypeName("time_t")]
        public long submitted;

        [NativeTypeName("const char *")]
        public sbyte* title;
    }
}
