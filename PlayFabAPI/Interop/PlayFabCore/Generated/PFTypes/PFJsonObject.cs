namespace PlayFab.Interop
{
    public unsafe partial struct PFJsonObject
    {
        [NativeTypeName("const char *")]
        public sbyte* stringValue;
    }
}
