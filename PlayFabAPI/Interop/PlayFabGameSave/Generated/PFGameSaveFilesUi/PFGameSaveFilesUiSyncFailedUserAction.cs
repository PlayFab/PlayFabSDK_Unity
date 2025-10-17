namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFGameSaveFilesUiSyncFailedUserAction : uint
    {
        Cancel = 0,
        Retry,
        UseOffline,
    }
}
