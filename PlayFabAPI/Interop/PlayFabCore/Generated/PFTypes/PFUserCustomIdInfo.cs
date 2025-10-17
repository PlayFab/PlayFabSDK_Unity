namespace PlayFab.Interop
{
    public unsafe partial struct PFUserCustomIdInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* customId;
    }
}
