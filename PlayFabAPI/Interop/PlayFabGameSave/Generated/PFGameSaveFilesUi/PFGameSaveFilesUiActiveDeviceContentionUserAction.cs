namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFGameSaveFilesUiActiveDeviceContentionUserAction : uint
    {
        Cancel = 0,
        Retry,
        SyncLastSavedData,
    }
}
