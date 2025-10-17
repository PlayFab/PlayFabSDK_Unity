namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryGetMicrosoftStoreAccessTokensResponse
    {
        [NativeTypeName("const char *")]
        public sbyte* collectionsAccessToken;

        [NativeTypeName("time_t")]
        public long collectionsAccessTokenExpirationDate;
    }
}
