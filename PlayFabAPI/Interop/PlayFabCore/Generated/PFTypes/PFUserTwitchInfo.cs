namespace PlayFab.Interop
{
    public unsafe partial struct PFUserTwitchInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* twitchId;

        [NativeTypeName("const char *")]
        public sbyte* twitchUserName;
    }
}
