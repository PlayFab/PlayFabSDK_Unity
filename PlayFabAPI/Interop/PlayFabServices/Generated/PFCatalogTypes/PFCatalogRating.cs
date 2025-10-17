namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogRating
    {
        [NativeTypeName("const float *")]
        public float* average;

        [NativeTypeName("const int32_t *")]
        public int* count1Star;

        [NativeTypeName("const int32_t *")]
        public int* count2Star;

        [NativeTypeName("const int32_t *")]
        public int* count3Star;

        [NativeTypeName("const int32_t *")]
        public int* count4Star;

        [NativeTypeName("const int32_t *")]
        public int* count5Star;

        [NativeTypeName("const int32_t *")]
        public int* totalCount;
    }
}
