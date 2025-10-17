namespace PlayFab.Interop
{
    public unsafe partial struct PFUserTitleInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* avatarUrl;

        [NativeTypeName("time_t")]
        public long created;

        [NativeTypeName("const char *")]
        public sbyte* displayName;

        [NativeTypeName("const time_t *")]
        public long* firstLogin;

        [NativeTypeName("const bool *")]
        public byte* isBanned;

        [NativeTypeName("const time_t *")]
        public long* lastLogin;

        [NativeTypeName("const PFUserOrigination *")]
        public PFUserOrigination* origination;

        [NativeTypeName("const PFEntityKey *")]
        public PFEntityKey* titlePlayerAccount;
    }
}
