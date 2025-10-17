namespace PlayFab.Interop
{
    public unsafe partial struct PFGroupsUpdateGroupRoleResponse
    {
        [NativeTypeName("const char *")]
        public sbyte* operationReason;

        [NativeTypeName("int32_t")]
        public int profileVersion;

        [NativeTypeName("const PFOperationTypes *")]
        public PFOperationTypes* setResult;
    }
}
