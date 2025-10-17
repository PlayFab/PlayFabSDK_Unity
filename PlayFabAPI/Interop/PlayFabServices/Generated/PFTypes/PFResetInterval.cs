namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFResetInterval : uint
    {
        Manual,
        Hour,
        Day,
        Week,
        Month,
    }
}
