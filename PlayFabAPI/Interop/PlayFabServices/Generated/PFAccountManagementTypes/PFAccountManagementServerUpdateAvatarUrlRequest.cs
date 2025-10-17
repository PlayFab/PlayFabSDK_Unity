namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementServerUpdateAvatarUrlRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* imageUrl;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
