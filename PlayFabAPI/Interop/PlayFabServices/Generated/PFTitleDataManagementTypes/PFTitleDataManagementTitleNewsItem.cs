namespace PlayFab.Interop
{
    public unsafe partial struct PFTitleDataManagementTitleNewsItem
    {
        [NativeTypeName("const char *")]
        public sbyte* body;

        [NativeTypeName("const char *")]
        public sbyte* newsId;

        [NativeTypeName("time_t")]
        public long timestamp;

        [NativeTypeName("const char *")]
        public sbyte* title;
    }
}
