namespace PlayFab.Interop
{
    public unsafe partial struct PFInventoryGooglePlayProductPurchase
    {
        [NativeTypeName("const char *")]
        public sbyte* productId;

        [NativeTypeName("const char *")]
        public sbyte* token;
    }
}
