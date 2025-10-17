namespace PlayFab.Interop
{
    public unsafe partial struct PFProfilesSetProfileLanguageResponse
    {
        [NativeTypeName("const PFOperationTypes *")]
        public PFOperationTypes* operationResult;

        [NativeTypeName("const int32_t *")]
        public int* versionNumber;
    }
}
