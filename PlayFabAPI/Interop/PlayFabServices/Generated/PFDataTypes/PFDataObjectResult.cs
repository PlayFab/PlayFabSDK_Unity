namespace PlayFab.Interop
{
    public unsafe partial struct PFDataObjectResult
    {
        public PFJsonObject dataObject;

        [NativeTypeName("const char *")]
        public sbyte* escapedDataObject;

        [NativeTypeName("const char *")]
        public sbyte* objectName;
    }
}
