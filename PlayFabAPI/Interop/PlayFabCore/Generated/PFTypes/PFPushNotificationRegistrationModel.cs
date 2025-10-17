namespace PlayFab.Interop
{
    public unsafe partial struct PFPushNotificationRegistrationModel
    {
        [NativeTypeName("const char *")]
        public sbyte* notificationEndpointARN;

        [NativeTypeName("const PFPushNotificationPlatform *")]
        public PFPushNotificationPlatform* platform;
    }
}
