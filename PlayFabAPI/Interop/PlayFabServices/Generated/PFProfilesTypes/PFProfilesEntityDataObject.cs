namespace PlayFab.Interop
{
    public unsafe partial struct PFProfilesEntityDataObject
    {
        public PFJsonObject dataObject;

        [NativeTypeName("const char *")]
        public sbyte* escapedDataObject;

        [NativeTypeName("const char *")]
        public sbyte* objectName;
    }
}
