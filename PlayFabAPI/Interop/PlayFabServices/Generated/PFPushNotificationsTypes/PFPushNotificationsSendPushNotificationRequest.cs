namespace PlayFab.Interop
{
    public unsafe partial struct PFPushNotificationsSendPushNotificationRequest
    {
        [NativeTypeName("const PFPushNotificationsAdvancedPushPlatformMsg *const *")]
        public PFPushNotificationsAdvancedPushPlatformMsg** advancedPlatformDelivery;

        [NativeTypeName("uint32_t")]
        public uint advancedPlatformDeliveryCount;

        [NativeTypeName("const struct PFStringDictionaryEntry *")]
        public PFStringDictionaryEntry* customTags;

        [NativeTypeName("uint32_t")]
        public uint customTagsCount;

        [NativeTypeName("const char *")]
        public sbyte* message;

        [NativeTypeName("const PFPushNotificationsPushNotificationPackage *")]
        public PFPushNotificationsPushNotificationPackage* package;

        [NativeTypeName("const char *")]
        public sbyte* recipient;

        [NativeTypeName("const char *")]
        public sbyte* subject;

        [NativeTypeName("const PFPushNotificationPlatform *")]
        public PFPushNotificationPlatform* targetPlatforms;

        [NativeTypeName("uint32_t")]
        public uint targetPlatformsCount;
    }
}
