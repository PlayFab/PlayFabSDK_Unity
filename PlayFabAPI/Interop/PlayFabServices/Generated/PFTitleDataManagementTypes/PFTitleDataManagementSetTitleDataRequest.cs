namespace PlayFab.Interop
{
    public unsafe partial struct PFTitleDataManagementSetTitleDataRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* key;

        [NativeTypeName("const char *")]
        public sbyte* value;
    }
}
