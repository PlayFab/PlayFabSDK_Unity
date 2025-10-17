namespace PlayFab.Interop
{
    public unsafe partial struct PFVariable
    {
        [NativeTypeName("const char *")]
        public sbyte* name;

        [NativeTypeName("const char *")]
        public sbyte* value;
    }
}
