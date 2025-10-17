namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFCatalogModerationStatus : uint
    {
        Unknown,
        AwaitingModeration,
        Approved,
        Rejected,
    }
}
