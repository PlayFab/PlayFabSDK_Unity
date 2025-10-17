namespace PlayFab.Interop
{
    public unsafe partial struct PFUserXboxInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* xboxUserId;

        [NativeTypeName("const char *")]
        public sbyte* xboxUserSandbox;
    }
}
