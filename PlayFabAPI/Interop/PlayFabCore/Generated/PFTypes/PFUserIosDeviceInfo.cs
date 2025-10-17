namespace PlayFab.Interop
{
    public unsafe partial struct PFUserIosDeviceInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* iosDeviceId;
    }
}
