namespace PlayFab.Interop
{
    public unsafe partial struct PFTitleDataManagementSetPublisherDataRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("const char *")]
        public sbyte* value;
    }
}
