namespace PlayFab.Interop
{
    public unsafe partial struct PFEntityToken
    {
        [NativeTypeName("const char *")]
        public sbyte* token;

        [NativeTypeName("const time_t *")]
        public long* expiration;
    }
}
