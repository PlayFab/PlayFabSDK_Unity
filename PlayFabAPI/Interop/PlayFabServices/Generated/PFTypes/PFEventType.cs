namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFEventType : uint
    {
        None,
        Telemetry,
        PlayStream,
    }
}
