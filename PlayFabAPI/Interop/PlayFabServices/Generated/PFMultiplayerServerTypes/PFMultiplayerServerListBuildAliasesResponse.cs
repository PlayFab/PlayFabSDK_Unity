namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerListBuildAliasesResponse
    {
        [NativeTypeName("const PFMultiplayerServerBuildAliasDetailsResponse *const *")]
        public PFMultiplayerServerBuildAliasDetailsResponse** buildAliases;

        [NativeTypeName("uint32_t")]
        public uint buildAliasesCount;

        [NativeTypeName("int32_t")]
        public int pageSize;

        [NativeTypeName("const char *")]
        public sbyte* skipToken;
    }
}
