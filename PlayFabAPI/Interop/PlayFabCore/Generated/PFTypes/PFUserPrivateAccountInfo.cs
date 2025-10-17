namespace PlayFab.Interop
{
    public unsafe partial struct PFUserPrivateAccountInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* email;
    }
}
