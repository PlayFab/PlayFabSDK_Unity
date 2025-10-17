namespace PlayFab.Interop
{
    public unsafe partial struct PFAccountManagementRevokeBansRequest
    {
        [NativeTypeName("const char *const *")]
        public sbyte** banIds;

        [NativeTypeName("uint32_t")]
        public uint banIdsCount;
    }
}
