namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementGetPlayFabIDsFromNintendoServiceAccountIdsResult
    {
        [NativeTypeName("const PFAccountManagementNintendoServiceAccountPlayFabIdPair *const *")]
        public PFAccountManagementNintendoServiceAccountPlayFabIdPair** data;

        [NativeTypeName("uint32_t")]
        public uint dataCount;
    }
}
