namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFTitleActivationStatus : uint
    {
        None,
        ActivatedTitleKey,
        PendingSteam,
        ActivatedSteam,
        RevokedSteam,
    }
}
