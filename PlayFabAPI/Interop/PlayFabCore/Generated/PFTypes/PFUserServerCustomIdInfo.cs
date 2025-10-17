namespace PlayFab.Interop
{
    public unsafe partial struct PFUserServerCustomIdInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* customId;
    }
}
