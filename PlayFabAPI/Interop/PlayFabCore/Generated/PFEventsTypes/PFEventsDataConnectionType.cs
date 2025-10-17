namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFEventsDataConnectionType : uint
    {
        AzureBlobStorage,
        AzureDataExplorer,
        FabricKQL,
    }
}
