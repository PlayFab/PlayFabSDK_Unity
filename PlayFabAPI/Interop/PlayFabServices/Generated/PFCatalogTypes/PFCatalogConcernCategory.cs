namespace PlayFab.Interop
{
    [Interop.NativeTypeName("uint32_t")]
    public enum PFCatalogConcernCategory : uint
    {
        None,
        OffensiveContent,
        ChildExploitation,
        MalwareOrVirus,
        PrivacyConcerns,
        MisleadingApp,
        PoorPerformance,
        ReviewResponse,
        SpamAdvertising,
        Profanity,
    }
}
