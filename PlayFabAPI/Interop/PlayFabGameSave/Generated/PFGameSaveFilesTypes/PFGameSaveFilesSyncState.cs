namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFGameSaveFilesSyncState : uint
    {
        NotStarted = 0,
        PreparingForDownload,
        Downloading,
        PreparingForUpload,
        Uploading,
        SyncComplete,
    }
}
