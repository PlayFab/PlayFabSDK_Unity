namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFGameSaveFilesAddUserOptions : uint
    {
        None = 0x00,
        RollbackToLastKnownGood = 0x01,
        RollbackToLastConflict = 0x02,
    }
}
