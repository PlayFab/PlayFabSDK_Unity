namespace PlayFab.Interop
{
    public unsafe partial struct PFUserPsnInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* psnAccountId;

        [NativeTypeName("const char *")]
        public sbyte* psnOnlineId;
    }
}
