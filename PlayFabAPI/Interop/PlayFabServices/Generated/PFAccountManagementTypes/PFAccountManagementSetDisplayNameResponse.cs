namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementSetDisplayNameResponse
    {
        [NativeTypeName("const PFOperationTypes *")]
        public PFOperationTypes* operationResult;

        [NativeTypeName("const int32_t *")]
        public int* versionNumber;
    }
}
