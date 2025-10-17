namespace PlayFab.Interop
{
    public unsafe partial struct PFPushNotificationsAdvancedPushPlatformMsg
    {
        [NativeTypeName("const bool *")]
        public byte* gCMDataOnly;

        [NativeTypeName("const char *")]
        public sbyte* json;

        public PFPushNotificationPlatform platform;
    }
}
