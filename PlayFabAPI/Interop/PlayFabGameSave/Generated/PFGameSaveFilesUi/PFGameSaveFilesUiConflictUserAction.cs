namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFGameSaveFilesUiConflictUserAction : uint
    {
        Cancel = 0,
        TakeLocal,
        TakeRemote,
    }
}
