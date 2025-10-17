namespace PlayFab.Interop
{
    public unsafe partial struct PFEventsDataConnectionAzureBlobSettings
    {
        [NativeTypeName("const char *")]
        public sbyte* accountName;

        [NativeTypeName("const char *")]
        public sbyte* containerName;

        [NativeTypeName("const char *")]
        public sbyte* tenantId;
    }
}
