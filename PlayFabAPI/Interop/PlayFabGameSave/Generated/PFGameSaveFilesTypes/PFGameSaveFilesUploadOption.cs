namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFGameSaveFilesUploadOption : uint
    {
        KeepDeviceActive = 0,
        ReleaseDeviceAsActive,
    }
}
