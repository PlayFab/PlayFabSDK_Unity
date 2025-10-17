namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsUpdateGroupResponse
    {
        [NativeTypeName("const char *")]
        public sbyte* operationReason;

        [NativeTypeName("int32_t")]
        public int profileVersion;

        [NativeTypeName("const PFOperationTypes *")]
        public PFOperationTypes* setResult;
    }
}
