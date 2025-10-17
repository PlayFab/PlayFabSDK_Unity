namespace PlayFab.Interop
{
    public unsafe partial struct PFDataSetObject
    {
        public PFJsonObject dataObject;

        [NativeTypeName("const bool *")]
        public byte* deleteObject;

        [NativeTypeName("const char *")]
        public sbyte* escapedDataObject;

        [NativeTypeName("const char *")]
        public sbyte* objectName;
    }
}
