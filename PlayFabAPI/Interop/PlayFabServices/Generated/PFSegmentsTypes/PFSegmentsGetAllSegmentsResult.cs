namespace PlayFab.Interop
{
    public unsafe partial struct PFSegmentsGetAllSegmentsResult
    {
        [NativeTypeName("const PFSegmentsGetSegmentResult *const *")]
        public PFSegmentsGetSegmentResult** segments;

        [NativeTypeName("uint32_t")]
        public uint segmentsCount;
    }
}
