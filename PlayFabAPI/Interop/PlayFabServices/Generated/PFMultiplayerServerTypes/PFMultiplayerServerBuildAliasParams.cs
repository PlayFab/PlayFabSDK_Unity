namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerBuildAliasParams
    {
        [NativeTypeName("const char *")]
        public sbyte* aliasId;
    }
}
