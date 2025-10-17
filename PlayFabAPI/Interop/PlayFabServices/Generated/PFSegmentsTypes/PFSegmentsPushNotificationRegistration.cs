namespace PlayFab.Interop
{
    public unsafe partial struct PFSegmentsPushNotificationRegistration
    {
        [NativeTypeName("const char *")]
        public sbyte* notificationEndpointARN;

        [NativeTypeName("const PFPushNotificationPlatform *")]
        public PFPushNotificationPlatform* platform;
    }
}
