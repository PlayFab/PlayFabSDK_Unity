namespace PlayFab.Interop
{
    public unsafe partial struct PFEventsDataConnectionSettings
    {
        [NativeTypeName("const PFEventsDataConnectionAzureBlobSettings *")]
        public PFEventsDataConnectionAzureBlobSettings* azureBlobSettings;

        [NativeTypeName("const PFEventsDataConnectionAzureDataExplorerSettings *")]
        public PFEventsDataConnectionAzureDataExplorerSettings* azureDataExplorerSettings;

        [NativeTypeName("const PFEventsDataConnectionFabricKQLSettings *")]
        public PFEventsDataConnectionFabricKQLSettings* azureFabricKQLSettings;
    }
}
