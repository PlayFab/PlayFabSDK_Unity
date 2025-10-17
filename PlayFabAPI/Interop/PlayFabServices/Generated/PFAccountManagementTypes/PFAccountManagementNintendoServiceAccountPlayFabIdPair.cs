namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementNintendoServiceAccountPlayFabIdPair
    {
        [NativeTypeName("const char *")]
        public sbyte* nintendoServiceAccountId;

        [NativeTypeName("const char *")]
        public sbyte* playFabId;
    }
}
