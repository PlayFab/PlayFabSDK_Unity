namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerSecret
    {
        [NativeTypeName("const time_t *")]
        public long* expirationDate;

        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* value;
    }
}
