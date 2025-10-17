namespace PlayFab.Interop
{
    public unsafe partial struct PFMultiplayerServerBuildAliasDetailsResponse
    {
        [NativeTypeName("const char *")]
        public sbyte* aliasId;

        [NativeTypeName("const char *")]
        public sbyte* aliasName;

        [NativeTypeName("const PFMultiplayerServerBuildSelectionCriterion *const *")]
        public PFMultiplayerServerBuildSelectionCriterion** buildSelectionCriteria;

        [NativeTypeName("uint32_t")]
        public uint buildSelectionCriteriaCount;
    }
}
