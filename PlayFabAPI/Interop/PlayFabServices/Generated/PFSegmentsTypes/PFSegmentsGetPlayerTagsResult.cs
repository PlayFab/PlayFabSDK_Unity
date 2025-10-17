namespace PlayFab.Interop
{
    public unsafe partial struct PFSegmentsGetPlayerTagsResult
    {
        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const char *const *")]
        public sbyte** tags;

        [NativeTypeName("uint32_t")]
        public uint tagsCount;
    }
}
