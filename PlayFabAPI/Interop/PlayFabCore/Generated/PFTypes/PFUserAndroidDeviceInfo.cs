namespace PlayFab.Interop
{
    public unsafe partial struct PFUserAndroidDeviceInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* androidDeviceId;
    }
}
