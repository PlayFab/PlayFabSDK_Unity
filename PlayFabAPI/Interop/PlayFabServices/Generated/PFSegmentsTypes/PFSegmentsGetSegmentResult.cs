namespace PlayFab.Interop
{
    public unsafe partial struct PFSegmentsGetSegmentResult
    {
        [NativeTypeName("const char *")]
        public sbyte* aBTestParent;

        [NativeTypeName("const char *")]
        public sbyte* id;

        [NativeTypeName("const char *")]
        public sbyte* name;
    }
}
