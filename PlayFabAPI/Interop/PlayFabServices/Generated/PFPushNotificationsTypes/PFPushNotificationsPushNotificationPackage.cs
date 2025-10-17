namespace PlayFab.Interop
{
    public unsafe partial struct PFPushNotificationsPushNotificationPackage
    {
        [NativeTypeName("int32_t")]
        public int badge;

        [NativeTypeName("const char *")]
        public sbyte* customData;

        [NativeTypeName("const char *")]
        public sbyte* icon;

        [NativeTypeName("const char *")]
        public sbyte* message;

        [NativeTypeName("const char *")]
        public sbyte* sound;

        [NativeTypeName("const char *")]
        public sbyte* title;
    }
}
