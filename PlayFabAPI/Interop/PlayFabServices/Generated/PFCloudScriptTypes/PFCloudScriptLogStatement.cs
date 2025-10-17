namespace PlayFab.Interop
{
    public unsafe partial struct PFCloudScriptLogStatement
    {
        public PFJsonObject data;

        [NativeTypeName("const char *")]
        public sbyte* level;

        [NativeTypeName("const char *")]
        public sbyte* message;
    }
}
