namespace PlayFab.Interop
{
    public unsafe partial struct PFDataSetObjectInfo
    {
        [NativeTypeName("const char *")]
        public sbyte* objectName;

        [NativeTypeName("const char *")]
        public sbyte* operationReason;

        [NativeTypeName("const PFOperationTypes *")]
        public PFOperationTypes* setResult;
    }
}
