namespace PlayFab.Interop
{
    public unsafe partial struct PFPlatformSpecificRegisterForIOSPushNotificationRequest
    {
        [NativeTypeName("const char *")]
        public sbyte* confirmationMessage;

        [NativeTypeName("const char *")]
        public sbyte* deviceToken;

        [NativeTypeName("const bool *")]
        public byte* sendPushNotificationConfirmation;
    }
}
