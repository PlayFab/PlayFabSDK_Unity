namespace PlayFab.Interop
{
    public unsafe partial struct PFTagModel
    {
        [NativeTypeName("const char *")]
        public sbyte* tagValue;
    }
}
