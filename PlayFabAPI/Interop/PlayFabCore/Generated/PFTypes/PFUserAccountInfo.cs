namespace PlayFab.Interop
{
    public unsafe partial struct PFUserAccountInfo
    {
        [NativeTypeName("const PFUserAndroidDeviceInfo *")]
        public PFUserAndroidDeviceInfo* androidDeviceInfo;

        [NativeTypeName("const PFUserAppleIdInfo *")]
        public PFUserAppleIdInfo* appleAccountInfo;

        [NativeTypeName("const PFUserBattleNetInfo *")]
        public PFUserBattleNetInfo* battleNetAccountInfo;

        [NativeTypeName("time_t")]
        public long created;

        [NativeTypeName("const PFUserCustomIdInfo *")]
        public PFUserCustomIdInfo* customIdInfo;

        [NativeTypeName("const PFUserFacebookInfo *")]
        public PFUserFacebookInfo* facebookInfo;

        [NativeTypeName("const PFUserFacebookInstantGamesIdInfo *")]
        public PFUserFacebookInstantGamesIdInfo* facebookInstantGamesIdInfo;

        [NativeTypeName("const PFUserGameCenterInfo *")]
        public PFUserGameCenterInfo* gameCenterInfo;

        [NativeTypeName("const PFUserGoogleInfo *")]
        public PFUserGoogleInfo* googleInfo;

        [NativeTypeName("const PFUserGooglePlayGamesInfo *")]
        public PFUserGooglePlayGamesInfo* googlePlayGamesInfo;

        [NativeTypeName("const PFUserIosDeviceInfo *")]
        public PFUserIosDeviceInfo* iosDeviceInfo;

        [NativeTypeName("const PFUserKongregateInfo *")]
        public PFUserKongregateInfo* kongregateInfo;

        [NativeTypeName("const PFUserNintendoSwitchAccountIdInfo *")]
        public PFUserNintendoSwitchAccountIdInfo* nintendoSwitchAccountInfo;

        [NativeTypeName("const PFUserNintendoSwitchDeviceIdInfo *")]
        public PFUserNintendoSwitchDeviceIdInfo* nintendoSwitchDeviceIdInfo;

        [NativeTypeName("const PFUserOpenIdInfo *const *")]
        public PFUserOpenIdInfo** openIdInfo;

        [NativeTypeName("uint32_t")]
        public uint openIdInfoCount;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;

        [NativeTypeName("const PFUserPrivateAccountInfo *")]
        public PFUserPrivateAccountInfo* privateInfo;

        [NativeTypeName("const PFUserPsnInfo *")]
        public PFUserPsnInfo* psnInfo;

        [NativeTypeName("const PFUserServerCustomIdInfo *")]
        public PFUserServerCustomIdInfo* serverCustomIdInfo;

        [NativeTypeName("const PFUserSteamInfo *")]
        public PFUserSteamInfo* steamInfo;

        [NativeTypeName("const PFUserTitleInfo *")]
        public PFUserTitleInfo* titleInfo;

        [NativeTypeName("const PFUserTwitchInfo *")]
        public PFUserTwitchInfo* twitchInfo;

        [NativeTypeName("const char *")]
        public sbyte* username;

        [NativeTypeName("const PFUserXboxInfo *")]
        public PFUserXboxInfo* xboxInfo;
    }
}
