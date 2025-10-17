namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFEmailVerificationStatus : uint
    {
        Unverified,
        Pending,
        Confirmed,
    }
}
