namespace PlayFab.Interop
{
    public unsafe partial struct PFDataSetObjectsResponse
    {
        [NativeTypeName("int32_t")]
        public int profileVersion;

        [NativeTypeName("const PFDataSetObjectInfo *const *")]
        public PFDataSetObjectInfo** setResults;

        [NativeTypeName("uint32_t")]
        public uint setResultsCount;
    }
}
