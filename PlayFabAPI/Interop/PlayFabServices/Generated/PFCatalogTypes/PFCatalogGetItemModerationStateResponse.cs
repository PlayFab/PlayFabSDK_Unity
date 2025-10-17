namespace PlayFab.Interop
{
    public unsafe partial struct PFCatalogGetItemModerationStateResponse
    {
        [NativeTypeName("const PFCatalogModerationState *")]
        public PFCatalogModerationState* state;
    }
}
