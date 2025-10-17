namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFCatalogPublishResult : uint
    {
        Unknown,
        Pending,
        Succeeded,
        Failed,
        Canceled,
    }
}
