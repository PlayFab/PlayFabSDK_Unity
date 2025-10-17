namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFSubscriptionProviderStatus : uint
    {
        NoError,
        Cancelled,
        UnknownError,
        BillingError,
        ProductUnavailable,
        CustomerDidNotAcceptPriceChange,
        FreeTrial,
        PaymentPending,
    }
}
