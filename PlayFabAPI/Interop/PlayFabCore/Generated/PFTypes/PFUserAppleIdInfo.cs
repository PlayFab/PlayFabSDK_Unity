namespace PlayFab.Interop
{
    public unsafe partial struct PFUserAppleIdInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* appleSubjectId;
    }
}
