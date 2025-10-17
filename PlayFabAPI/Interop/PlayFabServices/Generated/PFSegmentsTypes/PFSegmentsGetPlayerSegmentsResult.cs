namespace PlayFab.Interop
{
    public unsafe partial struct PFSegmentsGetPlayerSegmentsResult
    {
        [NativeTypeName("const PFSegmentsGetSegmentResult *const *")]
        public PFSegmentsGetSegmentResult** segments;

        [NativeTypeName("uint32_t")]
        public uint segmentsCount;
    }
}
