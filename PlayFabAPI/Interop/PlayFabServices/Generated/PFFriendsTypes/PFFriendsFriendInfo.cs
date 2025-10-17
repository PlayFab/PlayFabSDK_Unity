namespace PlayFab.Interop
{
    public unsafe partial struct PFFriendsFriendInfo
    {
        [NativeTypeName("const PFUserFacebookInfo *")]
        public PFUserFacebookInfo* facebookInfo;

        [NativeTypeName("const char *")]
        public sbyte* friendPlayFabId;

        [NativeTypeName("const PFUserGameCenterInfo *")]
        public PFUserGameCenterInfo* gameCenterInfo;

        [NativeTypeName("const PFPlayerProfileModel *")]
        public PFPlayerProfileModel* profile;

        [NativeTypeName("const PFUserPsnInfo *")]
        public PFUserPsnInfo* PSNInfo;

        [NativeTypeName("const PFUserSteamInfo *")]
        public PFUserSteamInfo* steamInfo;

        [NativeTypeName("const char *const *")]
        public sbyte** tags;

        [NativeTypeName("uint32_t")]
        public uint tagsCount;

        [NativeTypeName("const char *")]
        public sbyte* titleDisplayName;

        [NativeTypeName("const char *")]
        public sbyte* username;

        [NativeTypeName("const PFUserXboxInfo *")]
        public PFUserXboxInfo* xboxInfo;
    }
}
